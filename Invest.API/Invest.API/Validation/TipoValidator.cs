using FluentValidation;
using Invest.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.API.Validation
{
    public class TipoValidator : AbstractValidator<Tipo>
    {
        public TipoValidator()
        {
            RuleFor(t => t.Nome)
                    .NotNull().WithMessage("Preencha o nome.")
                    .NotEmpty().WithMessage("Preencha o nome.")
                    .MinimumLength(2).WithMessage("Mínimo de caracteres é 2.")
                    .MaximumLength(50).WithMessage("Máximo de caracteres é 50.");

            RuleFor(t => t.Sigla)
                    .NotNull().WithMessage("Preencha a sigla.")
                    .NotEmpty().WithMessage("Preencha a sigla.")
                    .MinimumLength(2).WithMessage("Mínimo de caracteres é 2.")
                    .MaximumLength(10).WithMessage("Máximo de caracteres é 10.");

           RuleFor(t => t.Codigo)
                    .NotNull().WithMessage("Preencha o código.")
                    .NotEmpty().WithMessage("Preencha o código.");
        }
    
    }
}
