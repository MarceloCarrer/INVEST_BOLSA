using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.API.ViewModels
{
    public class RegistroViewModelValidator : AbstractValidator<RegistroViewModel>
    {
        public RegistroViewModelValidator()
        {
            RuleFor(r => r.NomeUsuario)
                .NotNull().WithMessage("Preencha o Nome do Usuário.")
                .NotEmpty().WithMessage("Preencha o Nome do Usuário.")
                .MinimumLength(2).WithMessage("Mínimo de caracteres é 2.")
                .MaximumLength(50).WithMessage("Máximo de caracteres é 50.");

            RuleFor(r => r.CPF)
                .NotNull().WithMessage("Preencha o CPF.")
                .NotEmpty().WithMessage("Preencha o CPF.")
                .MinimumLength(11).WithMessage("Mínimo de caracteres é 11.")
                .MaximumLength(11).WithMessage("Máximo de caracteres é 11.");

            /*RuleFor(r => r.Foto)
                .NotNull().WithMessage("Escolha a Foto.")
                .NotEmpty().WithMessage("Escolha a Foto.");*/

            RuleFor(r => r.Email)
                .NotNull().WithMessage("Preencha o Email.")
                .NotEmpty().WithMessage("Preencha o Email.")
                .MinimumLength(5).WithMessage("Mínimo de caracteres é 5.")
                .MaximumLength(50).WithMessage("Máximo de caracteres é 50.")
                .EmailAddress().WithMessage("Email Inválido.");

            RuleFor(r => r.Senha)
                .NotNull().WithMessage("Preencha a Senha.")
                .NotEmpty().WithMessage("Preencha a Senha.")
                .MinimumLength(8).WithMessage("Mínimo de caracteres é 8.")
                .MaximumLength(30).WithMessage("Máximo de caracteres é 30.");
        }
    }
}
