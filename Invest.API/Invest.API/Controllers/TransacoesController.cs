using Invest.BLL.Models;
using Invest.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invest.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransacoesController : ControllerBase
    {
        private readonly ITransacaoRepository _transacaoRepository;

        public TransacoesController(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }
        
        [HttpGet("transacoesUsuarioId/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Transacao>>> GetTransacoesUsuarioId(string usuarioId)
        {
            return await _transacaoRepository.GetTransacaoForUserId(usuarioId).ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Transacao>> GetTransacao(int id)
        {
            Transacao transacao = await _transacaoRepository.GetId(id);

            if (transacao == null)
            {
                return NotFound();
            }

            return transacao;
        }

        [HttpGet("filtrarTransacoes/{nomeAtivo}")]
        public async Task<ActionResult<IEnumerable<Transacao>>> FilterAtivo(string nomeAtivo)
        {
            return await _transacaoRepository.FiltrarTransacoes(nomeAtivo).ToListAsync();
        }

        [HttpGet("filtrarVendidos/{vendido}")]
        public async Task<ActionResult<IEnumerable<Transacao>>> FilterVendidos(bool vendido)
        {
            return await _transacaoRepository.FiltrarVendidos(vendido).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Transacao>> PostTransacao(Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                await _transacaoRepository.Add(transacao);

                return Ok(new
                {
                    mensagem = $"Transação de {transacao.DiaCompra}/{transacao.MesIdCompra}/{transacao.AnoCompra} cadastrado."
                });
            }

            return BadRequest(transacao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTransacao(int id, Transacao transacao)
        {
            if (id != transacao.TransacaoId)
            {
                return BadRequest(transacao);
            }

            if (ModelState.IsValid)
            {
                await _transacaoRepository.Update(transacao);

                return Ok(new
                {
                    mensagem = $"Transação de {transacao.DiaCompra}/{transacao.MesIdCompra}/{transacao.AnoCompra} atualizada."
                });
            }

            return BadRequest(transacao);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransacao(int id)
        {
            Transacao transacao = await _transacaoRepository.GetId(id);

            if (transacao == null)
            {
                return NotFound();
            }

            await _transacaoRepository.Delete(transacao);

            return Ok(new
            {
                mensagem = $"Transação de {transacao.DiaCompra}/{transacao.MesIdCompra}/{transacao.AnoCompra} excluída."
            });
        }
    }
}
