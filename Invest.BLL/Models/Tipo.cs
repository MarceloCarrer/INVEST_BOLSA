using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.BLL.Models
{
    public class Tipo
    {
        public int TipoId { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public int Codigo { get; set; }

        public virtual ICollection<Transacao> Transacoes { get; set; }
    }
}
