using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Invest.BLL.Models;
using Invest.DAL;
using Invest.DAL.Interfaces;
using Invest.DAL.Repository;
using System.IO;
using Invest.API.ViewModels;
using Microsoft.AspNetCore.Identity;
using Invest.API.Services;

namespace Invest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<AtualizarUsuarioViewModel>> GetUsuario(string id)
        {
            var usuario = await _usuarioRepository.GetId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            AtualizarUsuarioViewModel model = new AtualizarUsuarioViewModel
            {
                Id = usuario.Id,
                NomeUsuario = usuario.UserName,
                Email = usuario.Email,
                CPF = usuario.CPF,
                Foto = usuario.Foto
            };

            return model;
        }
        
        [HttpPost("salvarFoto")]
        public async Task<ActionResult> SalvarFoto()
        {
            /*
            var foto = Request.Form.Files[0];
            byte[] b;

            using (var openReadStream = foto.OpenReadStream())
            {
                using (var memoryStream = new MemoryStream())
                {
                    await openReadStream.CopyToAsync(memoryStream);
                    b = memoryStream.ToArray();
                }
            }

            return Ok(new
            {
                foto = b
            });*/

            return Ok();
        }
       
        [HttpPost("registrarUsuario")]
        public async Task<ActionResult> RegistrarUsuario(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult usuarioCriado;
                string funcaoUsuario;

                Usuario usuario = new Usuario
                {
                    UserName = model.NomeUsuario,
                    Email = model.Email,
                    PasswordHash = model.Senha,
                    CPF = model.CPF,
                    Foto = model.Foto
                };

                if (await _usuarioRepository.GetAmountRegistersUsers() > 0)
                {
                    funcaoUsuario = "Usuario";
                }
                else
                {
                    funcaoUsuario = "Administrador";
                }

                usuarioCriado = await _usuarioRepository.CreateUser(usuario, model.Senha);

                if (usuarioCriado.Succeeded)
                {
                    await _usuarioRepository.IncludeUserFunction(usuario, funcaoUsuario);
                    var token = TokenService.GerarToken(usuario, funcaoUsuario);
                    await _usuarioRepository.LoginUser(usuario, false);

                    return Ok(new
                    {
                        emailUserLogin = usuario.Email,
                        usuarioId = usuario.Id,
                        tokenUsuarioLogado = token
                    });
                }
                else
                {
                    return BadRequest(model);
                }

            }

            return BadRequest(model);
        }

        [HttpPost("logarUsuario")]
        public async Task<ActionResult> LogarUsuario(LoginViewModel model)
        {
            if (model == null)
            {
                return NotFound("Usuário ou senha inválidos.");
            }

            Usuario usuario = await _usuarioRepository.GetUserEmail(model.Email);

            if (usuario != null)
            {
                PasswordHasher<Usuario> passwordHasher = new PasswordHasher<Usuario>();

                if (passwordHasher.VerifyHashedPassword(usuario, usuario.PasswordHash, model.Senha) != PasswordVerificationResult.Failed)
                {
                    var funcoesUsuario = await _usuarioRepository.GetFunctionUser(usuario);
                    var token = TokenService.GerarToken(usuario, funcoesUsuario.First());
                    await _usuarioRepository.LoginUser(usuario, false);

                    return Ok(new
                    {
                        emailUsuarioLogado = usuario.Email,
                        usuarioId = usuario.Id,
                        tokenUsuarioLogado = token
                    });
                }
                return NotFound("Usuário ou senha inválidos.");
            }

            return NotFound("Usuário ou senha inválidos.");
        }

        [HttpPut("AtualizarUsuario")]
        public async Task<ActionResult> AtualizarUsuario(AtualizarUsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = await _usuarioRepository.GetId(model.Id);
                usuario.UserName = model.NomeUsuario;
                usuario.Email = model.Email;
                usuario.CPF = model.CPF;
                usuario.Foto = model.Foto;

                await _usuarioRepository.UpdateUser(usuario);

                return Ok(new
                {
                    mensagem = $"Usuário {usuario.UserName} atualizado com sucesso."
                });
            }

            return BadRequest(model);
        }
    }
}
