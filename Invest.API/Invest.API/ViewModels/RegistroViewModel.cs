using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.API.ViewModels
{
    public class RegistroViewModel
    {
        public string NomeUsuario { get; set; }

        public string CPF { get; set; }

        public byte[] Foto { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
