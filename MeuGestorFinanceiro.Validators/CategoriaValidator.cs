
using FluentValidation;
using MeuGestorFinanceiro.Domains;

namespace MeuGestorFinanceiro.Validators
{
    public class CategoriaValidator : AbstractValidator<CategoriaDomain>
    {
        public CategoriaValidator()
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("Campo Descrição é obrigatório.");
            RuleFor(x => x.Descricao).MaximumLength(50).WithMessage("O campo descrição pode ter até 50 caracteres.");
        }
    }
}
