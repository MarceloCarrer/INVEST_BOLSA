using FluentValidation;
using Invest.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.API.Validation
{
    public class FuncoesViewModelValidator : AbstractValidator<FuncoesViewModel>
    {
        public FuncoesViewModelValidator()
        {
            RuleFor(f => f.Name)
                .NotNull().WithMessage("Preencha a Função.")
                .NotEmpty().WithMessage("Preencha a Função.")
                .MinimumLength(2).WithMessage("Mínimo de caracteres é 2.")
                .MaximumLength(30).WithMessage("Máximo de caracteres é 30.");

            RuleFor(f => f.Descricao)
                .NotNull().WithMessage("Preencha a Descrição.")
                .NotEmpty().WithMessage("Preencha a Descrição.")
                .MinimumLength(2).WithMessage("Mínimo de caracteres é 2.")
                .MaximumLength(50).WithMessage("Máximo de caracteres é 50.");


        }
    }
}
