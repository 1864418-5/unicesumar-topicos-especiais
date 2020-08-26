namespace MeuGestorFinanceiro.Domains
{
    public class DespesaDomain : TransacaoAbstract
    {
        public bool Pago { get; set; }
        public virtual CategoriaDomain Categoria { get; set; }
    }
}
