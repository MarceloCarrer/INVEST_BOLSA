using FluentValidation;
using Invest.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.API.Validation
{
    public class InvestimentoValidator : AbstractValidator<Investimento>
    {
        public InvestimentoValidator()
        {
            RuleFor(t => t.Valor)
                    .NotNull().WithMessage("Preencha o valor.")
                    .NotEmpty().WithMessage("Preencha o valor.")
                    .InclusiveBetween(0.01, double.MaxValue).WithMessage("Valor não pode ser negativo.");

            RuleFor(t => t.Dia)
                    .NotNull().WithMessage("Preencha o dia da compra.")
                    .NotEmpty().WithMessage("Preencha o dia da compra.")
                    .InclusiveBetween(1, 31).WithMessage("Valor Inválido.");

            RuleFor(t => t.MesId)
                   .NotNull().WithMessage("Selecione o mês.")
                   .NotEmpty().WithMessage("Selecione o mês.");

            RuleFor(t => t.Ano)
                    .NotNull().WithMessage("Preencha o ano.")
                    .NotEmpty().WithMessage("Preencha o ano.")
                    .InclusiveBetween(2000, 2199).WithMessage("Valor Inválido.");
        }
    }
}
