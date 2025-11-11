using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using GRDA_TEP_DSP_000.Application.Model;

namespace GRDA_TEP_DSP_000.Application.Validator
{
    public class InsertPalestraValidator : AbstractValidator<CreatePalestraInputModel>
    {
        public InsertPalestraValidator()
        {
            RuleFor(p => p.Subject)
                .NotEmpty()
                    .WithMessage("Não pode ser vazio.")
                .MaximumLength(80)
                    .WithMessage("Tamanho máximo é 80 caracteres.");
            
            RuleFor(p => p.Trail)
                .NotEmpty()
                .IsInEnum()
                .WithMessage("Escolha entre Trilha 1 ou Trilha 2.");

            RuleFor(p => p.Start)
                .NotEmpty()
                .InclusiveBetween(TimeSpan.FromHours(9),(TimeSpan.FromHours(17)))
                .WithMessage("Frmato de Inicio HH:MM.");


            RuleFor(p => p.Finish)
                .NotEmpty()
                .InclusiveBetween(TimeSpan.FromHours(9), (TimeSpan.FromHours(17)))
                .WithMessage("Escolha entre Trilha 1 ou Trilha 2.")
                .WithMessage("Frmato de Fim HH:MM.");

        }
    }
}
