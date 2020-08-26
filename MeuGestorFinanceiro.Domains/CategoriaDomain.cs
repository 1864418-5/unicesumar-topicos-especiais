using System.Collections.Generic;

namespace MeuGestorFinanceiro.Domains
{
    public class CategoriaDomain
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual List<DespesaDomain> Despesas { get; set; }
        public virtual List<ReceitaDomain> Receitas { get; set; }
    }
}
