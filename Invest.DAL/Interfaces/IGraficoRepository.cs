using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.DAL.Interfaces
{
    public interface IGraficoRepository
    {
        object GetComprasForUserId(string usuarioId, int ano);

        object GetVendasForUserId(string usuarioId, int ano);
    }
}
