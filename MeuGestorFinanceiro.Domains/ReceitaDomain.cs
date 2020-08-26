
namespace MeuGestorFinanceiro.Domains
{
    public class ReceitaDomain : TransacaoAbstract
    {
        public bool Recebido { get; set; }
        public virtual CategoriaDomain Categoria { get; set; }
    }
}
