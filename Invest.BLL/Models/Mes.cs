using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.BLL.Models
{
    public class Mes
    {
        public int MesId { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Transacao> Transacoes { get; set; }
        public virtual ICollection<Investimento> Investimentos { get; set; }
    }
}
