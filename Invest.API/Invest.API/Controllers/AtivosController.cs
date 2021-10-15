using Invest.BLL.Models;
using Invest.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AtivosController : ControllerBase
    {
        private readonly IAtivoRepository _ativoRepository;
        private readonly ITransacaoRepository _transacaoRepository;

        public AtivosController(IAtivoRepository ativoRepository, ITransacaoRepository transacaoRepository)
        {
            _ativoRepository = ativoRepository;
            _transacaoRepository = transacaoRepository;
        }

        [HttpGet("ativosUsuarioId/{usuarioId}")]
        public async Task<IEnumerable<Ativo>> GetAtivosForUserId(string usuarioId)
        {
            return await _ativoRepository.GetAtivosForUserId(usuarioId).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ativo>> GetAtivo(int id)
        {
            Ativo ativo = await _ativoRepository.GetId(id);

            if (ativo == null)
            {
                return NotFound();
            }

            return ativo;
        }

       
        [HttpGet("filtrarAtivos/{nomeAtivo}")]
        public async Task<ActionResult<IEnumerable<Ativo>>> FilterAtivo(string nomeAtivo)
        {
            return await _ativoRepository.FiltrarAtivos(nomeAtivo).ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAtivo(int id, Ativo ativo)
        {
            if (id != ativo.AtivoId)
            {
                return BadRequest("Ativo diferente. Não foi possível atualizar.");
            }

            if (ModelState.IsValid)
            {
                await _ativoRepository.Update(ativo);

                return Ok(new
                {
                    mensagem = $"Ativo {ativo.Nome} atualizado com sucesso."
                });
            }

            return BadRequest(ativo);
        }

        [HttpPost]
        public async Task<ActionResult> PostAtivo(Ativo ativo)
        {
            if (ModelState.IsValid)
            {
                await _ativoRepository.Add(ativo);

                return Ok(new
                {
                    mensagem = $"Ativo {ativo.Nome} adicionado com sucesso."
                });
            }

            return BadRequest(ativo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAtivo(int id)
        {
            Ativo ativo = await _ativoRepository.GetId(id);

            if (ativo == null)
            {
                return NotFound();
            }

            IEnumerable<Transacao> transacoes = await _transacaoRepository.GetTransacaoForAtivoId(ativo.AtivoId);
            _transacaoRepository.DeleteTransacao(transacoes);

            await _ativoRepository.Delete(ativo);

            return Ok(new
            {
                mensagem = $"Ativo {ativo.Nome} excluído com sucesso."
            });
        }
    }
}
