using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.BLL.Models
{
    public class Transacao
    {
        public int TransacaoId { get; set; }        

        public int QtdCompra { get; set; }

        public double ValorCompra { get; set; }

        public int DiaCompra { get; set; }

        public int MesIdCompra { get; set; }

        public int AnoCompra { get; set; }


        public int? QtdVenda { get; set; }

        public double? ValorVenda { get; set; }

        public int? DiaVenda { get; set; }

        public int? MesIdVenda { get; set; }

        public int? AnoVenda { get; set; }


        public bool? Vendido { get; set; }
        

        public int AtivoId { get; set; }        
        public Ativo Ativo { get; set; }

        public int TipoId { get; set; }
        public Tipo Tipo { get; set; }

        public Mes Mes { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
