using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.BLL.Models
{
    public class Investimento
    {
        public int InvestimentoId { get; set; }

        public double Valor { get; set; }

        public int Dia { get; set; }

        public int Ano { get; set; }

        public int MesId { get; set; }
        public Mes Mes { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}
