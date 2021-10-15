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
using Invest.API.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Invest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class FuncoesController : ControllerBase
    {
        private readonly IFuncaoRepository _funcaoRepository;

        public FuncoesController(IFuncaoRepository funcaoRepository)
        {
            _funcaoRepository = funcaoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcao>>> GetFuncoes()
        {
            return await _funcaoRepository.GetAll().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Funcao>> GetFuncao(string id)
        {
            var funcao = await _funcaoRepository.GetId(id);

            if (funcao == null)
            {
                return NotFound();
            }

            return funcao;
        }

        [HttpGet("filtrarFuncao/{nomeFuncao}")]
        public async Task<ActionResult<IEnumerable<Funcao>>> FilterFuncao(string nomeFuncao)
        {
            return await _funcaoRepository.FiltrarFuncao(nomeFuncao).ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncao(string id, FuncoesViewModel funcoes)
        {
            if (id != funcoes.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                Funcao funcao = new Funcao
                {
                    Id = funcoes.Id,
                    Name = funcoes.Name,
                    Descricao = funcoes.Descricao
                };

                await _funcaoRepository.UpdateFuncao(funcao);

                return Ok(new
                {
                    mensagem = $"Função {funcao.Name} atualizada com sucesso."
                });
            }

            return BadRequest(ModelState);            
        }

        [HttpPost]
        public async Task<ActionResult<Funcao>> PostFuncao(FuncoesViewModel funcoes)
        {
            if (ModelState.IsValid)
            {
                Funcao funcao = new Funcao
                {
                    Name = funcoes.Name,
                    Descricao = funcoes.Descricao
                };

                await _funcaoRepository.AddFuncao(funcao); 
                
                return Ok(new
                {
                    mensagem = $"Função {funcao.Name} cadastrada com sucesso."
                });
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Funcao>> DeleteFuncao(string id)
        {
            var funcao = await _funcaoRepository.GetId(id);
            if (funcao == null)
            {
                return NotFound();
            }

            await _funcaoRepository.Delete(funcao);

            return Ok(new
            {
                mensagem = $"Função {funcao.Name} excluída com sucesso."
            });
        }
    }
}
