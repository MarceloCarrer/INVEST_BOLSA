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
using Microsoft.AspNetCore.Authorization;

namespace Invest.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TiposController : ControllerBase
    {
        private readonly ITipoRepository _tipoRepository;

        public TiposController(ITipoRepository tipoRepository)
        {
            _tipoRepository = tipoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo>>> GetTipos()
        {
            return await _tipoRepository.GetAll().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tipo>> GetTipo(int id)
        {
            var tipo = await _tipoRepository.GetId(id);

            if (tipo == null)
            {
                return NotFound();
            }

            return tipo;
        }

        [HttpGet("filtrarTipo/{nomeTipo}")]
        public async Task<ActionResult<IEnumerable<Tipo>>> FilterTipo(string nomeTipo)
        {
            return await _tipoRepository.FiltrarTipos(nomeTipo).ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipo(int id, Tipo tipo)
        {
            if (id != tipo.TipoId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _tipoRepository.Update(tipo);

                return Ok(new
                {
                    mensagem = $"Tipo {tipo.Nome} atualizado com sucesso"
                });
            }

            return BadRequest(ModelState);

            
        }

        [HttpPost]
        public async Task<ActionResult<Tipo>> PostTipo(Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                await _tipoRepository.Add(tipo);

                return Ok(new
                {
                    mensagem = $"Tipo {tipo.Nome} cadastrado com sucesso"
                });
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Tipo>> DeleteTipo(int id)
        {
            var tipo = await _tipoRepository.GetId(id);
            if (tipo == null)
            {
                return NotFound();
            }
                        
            await _tipoRepository.Delete(id);

            return Ok(new
            {
                mensagem = $"Tipo {tipo.Nome} excluído com sucesso"
            });

        }
    }
}
