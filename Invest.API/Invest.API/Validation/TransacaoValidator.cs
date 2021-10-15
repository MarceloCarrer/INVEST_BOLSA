using FluentValidation;
using Invest.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.API.Validation
{
    public class TransacaoValidator : AbstractValidator<Transacao>
    {
        public TransacaoValidator()
        {
            RuleFor(t => t.QtdCompra)
                    .NotNull().WithMessage("Preencha a quantidade.")
                    .NotEmpty().WithMessage("Preencha a quantidade.")
                    .InclusiveBetween(1, int.MaxValue).WithMessage("Valor não pode ser negativo.");

            RuleFor(t => t.ValorCompra)
                    .NotNull().WithMessage("Preencha o valor da compra.")
                    .NotEmpty().WithMessage("Preencha o valor da compra.")
                    .InclusiveBetween(0.01, double.MaxValue).WithMessage("Valor não pode ser negativo.");

            RuleFor(t => t.DiaCompra)
                    .NotNull().WithMessage("Preencha o dia da compra.")
                    .NotEmpty().WithMessage("Preencha o dia da compra.")
                    .InclusiveBetween(1, 31).WithMessage("Valor Inválido.");

            RuleFor(t => t.MesIdCompra)
                   .NotNull().WithMessage("Selecione o mês da compra.")
                   .NotEmpty().WithMessage("Selecione o mês da compra.");

            RuleFor(t => t.AnoCompra)
                    .NotNull().WithMessage("Preencha o ano da compra.")
                    .NotEmpty().WithMessage("Preencha o ano da compra.")
                    .InclusiveBetween(2000, 2199).WithMessage("Valor Inválido.");

            RuleFor(t => t.QtdVenda)
                    .InclusiveBetween(1, int.MaxValue).WithMessage("Valor não pode ser negativo.");

            RuleFor(t => t.ValorVenda)
                    .InclusiveBetween(0.01, double.MaxValue).WithMessage("Valor não pode ser negativo.");

            RuleFor(t => t.DiaVenda)
                    .InclusiveBetween(1, 31).WithMessage("Valor Inválido.");

            RuleFor(t => t.AnoVenda)
                    .InclusiveBetween(2000, 2199).WithMessage("Valor Inválido.");

        }
    }
}
