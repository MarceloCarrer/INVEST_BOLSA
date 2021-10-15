using Invest.API.ViewModels;
using Invest.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IAtivoRepository _ativoRepository;
        private readonly IMesRepository _mesRepository;
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IInvestimentoRepository _investimentoRepository;
        private readonly IGraficoRepository _graficoRepository;

        public DashBoardController(IAtivoRepository ativoRepository, 
                                   IMesRepository mesRepository, 
                                   ITransacaoRepository transacaoRepository, 
                                   IInvestimentoRepository investimentoRepository, 
                                   IGraficoRepository graficoRepository)
        {
            _ativoRepository = ativoRepository;
            _mesRepository = mesRepository;
            _transacaoRepository = transacaoRepository;
            _investimentoRepository = investimentoRepository;
            _graficoRepository = graficoRepository;
        }

        [HttpGet("dadosCardsDashboard/{usuarioId}")]
        public async Task<ActionResult<DadosCardsDashboardViewModel>> GetDataCardsDashboard(string usuarioId)
        {
            double investimentoTotal = Math.Round(await _investimentoRepository.GetInvestimentoTotalUserId(usuarioId), 2);
            double retornoTotal = Math.Round(await _transacaoRepository.GetTransacaoTotalUserId(usuarioId) + investimentoTotal, 2);
            double lucroTotal = Math.Round(await _transacaoRepository.GetTransacaoTotalUserId(usuarioId), 2);
            double retornoPorc = Math.Round(((retornoTotal / investimentoTotal) - 1) * 100, 2);

            DadosCardsDashboardViewModel model = new DadosCardsDashboardViewModel
            {
                InvestimentoTotal = investimentoTotal,
                RetornoTotal = retornoTotal,
                LucroTotal = lucroTotal,
                RetornoPorc = retornoPorc
            };

            return model;
        }

        [HttpGet("dadosAnuaisUsuarioId/{usuarioId}/{ano}")]
        public object GetDataYearForUserId(string usuarioId, int ano)
        {
            return (new
            {
                compras = _graficoRepository.GetComprasForUserId(usuarioId, ano),
                vendas = _graficoRepository.GetVendasForUserId(usuarioId, ano),
                meses = _mesRepository.GetAllMeses()
            });
        }
    }
}
