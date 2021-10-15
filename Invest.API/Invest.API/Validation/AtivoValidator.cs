using FluentValidation;
using Invest.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.API.Validation
{
    public class AtivoValidator : AbstractValidator<Ativo>
    {
        public AtivoValidator()
        {
            RuleFor(a => a.Nome)
                    .NotNull().WithMessage("Preencha o nome.")
                    .NotEmpty().WithMessage("Preencha o nome.")
                    .MinimumLength(2).WithMessage("Mínimo de caracteres é 2.")
                    .MaximumLength(50).WithMessage("Máximo de caracteres é 50.");

            RuleFor(a => a.Sigla)
                    .NotNull().WithMessage("Preencha a sigla.")
                    .NotEmpty().WithMessage("Preencha a sigla.")
                    .MinimumLength(2).WithMessage("Mínimo de caracteres é 4.")
                    .MaximumLength(10).WithMessage("Máximo de caracteres é 4.");

            RuleFor(a => a.Setor)
                    .NotNull().WithMessage("Preencha o setor.")
                    .NotEmpty().WithMessage("Preencha o setor.")
                    .MinimumLength(2).WithMessage("Mínimo de caracteres é 2.")
                    .MaximumLength(100).WithMessage("Máximo de caracteres é 100.");
        }
    }
}
