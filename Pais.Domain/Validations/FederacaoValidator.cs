using FluentValidation;
using Pais.Domain.Entities;

namespace Pais.Domain.Validations
{
    public class FederacaoValidator : AbstractValidator<Federacao>
    {
        public FederacaoValidator()
        {
            RuleFor(a => a.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório");

            RuleFor(a => a.Nome)
                .MaximumLength(50)
                .WithMessage("Nome deve ter no máximo 50 caracteres");

            RuleFor(a => a.Numero)
                .MaximumLength(5)
                .WithMessage("Número deve ter no máximo 5 caracteres");
        }
    }
}
