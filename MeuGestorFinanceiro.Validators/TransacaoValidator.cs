using FluentValidation;
using MeuGestorFinanceiro.Domains;
using MeuGestorFinanceiro.Repositories;

namespace MeuGestorFinanceiro.Validators
{
    public class TransacaoValidator : AbstractValidator<TransacaoAbstract>
    {
        public TransacaoValidator()
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage("Descrição é um campo obrigatório.");
            RuleFor(x => x.Descricao).MaximumLength(100).WithMessage("O campo descrição pode ter até 100 caracteres.");
            RuleFor(x => x.Valor).Must(ValidarValor).WithMessage("O valor precisa ser maior que zero");
            RuleFor(x => x.IdCategoria).Must(ValidarCategoria).WithMessage("Escolha uma categoria válida");
        }

        private bool ValidarCategoria(int idCategoria)
        {
            return new CategoriaRepository().VerificarExistenciaCategoria(idCategoria);
        }

        private bool ValidarValor(decimal valor)
        {
            return valor > 0 ? true : false;
        }
    }
}
