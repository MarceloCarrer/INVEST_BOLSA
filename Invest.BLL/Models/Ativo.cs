using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.BLL.Models
{
    public class Ativo
    {
        public int AtivoId { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public string Setor { get; set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public virtual ICollection<Transacao> Transacoes { get; set; }
    }
}
