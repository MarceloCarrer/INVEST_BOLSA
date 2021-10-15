using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Invest.BLL.Models
{
    public class Usuario : IdentityUser<string>
    {
        public string CPF { get; set; }

        public byte[] Foto { get; set; }

        public virtual ICollection<Ativo> Ativos{ get; set; }
        public virtual ICollection<Transacao> Transacoes { get; set; }
        public virtual ICollection<Investimento> Investimentos { get; set; }

    }
}
