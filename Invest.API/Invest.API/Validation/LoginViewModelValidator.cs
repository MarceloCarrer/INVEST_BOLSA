using FluentValidation;
using Invest.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.API.Validation
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(l => l.Email)
                .NotNull().WithMessage("Preencha o Emali.")
                .NotNull().WithMessage("Preencha o Emali.")
                .MinimumLength(5).WithMessage("Mínimo de caracteres é 5.")
                .MaximumLength(50).WithMessage("Máximo de caracteres é 50.");

            RuleFor(f => f.Senha)
                .NotNull().WithMessage("Preencha a Senha.")
                .NotEmpty().WithMessage("Preencha a Senha.")
                .MinimumLength(8).WithMessage("Mínimo de caracteres é 8.")
                .MaximumLength(30).WithMessage("Máximo de caracteres é 30.");
        }
    }
}
