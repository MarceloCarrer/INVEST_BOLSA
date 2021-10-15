using Invest.BLL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invest.DAL.Interfaces
{
    public interface IUsuarioRepository : IRepositoryGeneric<Usuario>
    {
        Task<int> GetAmountRegistersUsers();

        Task<IdentityResult> CreateUser(Usuario usuario, string senha);

        Task IncludeUserFunction(Usuario usuario, string funcao);

        Task LoginUser(Usuario usuario, bool lembrar);

        Task<Usuario> GetUserEmail(string email);

        Task<IList<string>> GetFunctionUser(Usuario usuario);

        Task UpdateUser(Usuario usuario);
    }
}
