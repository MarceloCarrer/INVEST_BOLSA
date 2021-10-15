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
    public class InvestimentosController : ControllerBase
    {
        private readonly IInvestimentoRepository _investimentoRepository;

        public InvestimentosController(IInvestimentoRepository investimentoRepository)
        {
            _investimentoRepository = investimentoRepository;
        }

        [HttpGet("investimentosUsuarioId/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Investimento>>> GetInvestimentoUsuarioId(string usuarioId)
        {
            return await _investimentoRepository.GetInvestimentoForUserId(usuarioId).ToListAsync();
        }

        [HttpGet("filtrarInvestimentos/{valor}")]
        public async Task<ActionResult<IEnumerable<Investimento>>> FilterInvestimentos(int ano)
        {
            return await _investimentoRepository.FiltrarInvestimentos(ano).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Investimento>> GetInvestimento(int id)
        {
            Investimento investimento = await _investimentoRepository.GetId(id);

            if (investimento == null)
            {
                return NotFound();
            }

            return investimento;
        }

        [HttpPost]
        public async Task<ActionResult<Investimento>> PostInvestimento(Investimento investimento)
        {
            if (ModelState.IsValid)
            {
                await _investimentoRepository.Add(investimento);

                return Ok(new
                {
                    mensagem = $"Investimento de R$ {investimento.Valor} na data de {investimento.Dia}/{investimento.MesId}/{investimento.Ano} cadastrado."
                });
            }

            return BadRequest(investimento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutInvestimento(int id, Investimento investimento)
        {
            if (id != investimento.InvestimentoId)
            {
                return BadRequest(investimento);
            }

            if (ModelState.IsValid)
            {
                await _investimentoRepository.Update(investimento);

                return Ok(new
                {
                    mensagem = $"Investimento de R$ {investimento.Valor} na data de {investimento.Dia}/{investimento.MesId}/{investimento.Ano} atualizada."
                });
            }

            return BadRequest(investimento);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInvestimento(int id)
        {
            Investimento investimento = await _investimentoRepository.GetId(id);

            if (investimento == null)
            {
                return NotFound();
            }

            await _investimentoRepository.Delete(investimento);

            return Ok(new
            {
                mensagem = $"Investimento de R$ {investimento.Valor} na data de {investimento.Dia}/{investimento.MesId}/{investimento.Ano} excluída."
            });
        }

    }
}
