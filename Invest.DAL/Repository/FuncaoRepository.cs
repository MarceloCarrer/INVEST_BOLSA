using Invest.BLL.Models;
using Invest.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invest.DAL.Repository
{
    public class FuncaoRepository : RepositoryGeneric<Funcao>, IFuncaoRepository
    {
        private readonly Context _context;
        private readonly RoleManager<Funcao> _gerenciadorFuncoes;

        public FuncaoRepository(Context context, RoleManager<Funcao> gerenciadorFuncoes) : base(context)
        {
            _context = context;
            _gerenciadorFuncoes = gerenciadorFuncoes;
        }       

        public async Task AddFuncao(Funcao funcao)
        {
            try
            {
                await _gerenciadorFuncoes.CreateAsync(funcao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Funcao> FiltrarFuncao(string nomeFuncao)
        {
            try
            {
                var entity = _context.Funcoes.Where(f => f.Name.Contains(nomeFuncao));
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateFuncao(Funcao funcao)
        {
            try
            {
                Funcao f = await GetId(funcao.Id);
                f.Name = funcao.Name;
                f.NormalizedName = funcao.NormalizedName;
                f.Descricao = funcao.Descricao;

                await _gerenciadorFuncoes.UpdateAsync(f);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
