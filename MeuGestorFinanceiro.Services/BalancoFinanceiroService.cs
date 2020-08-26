
using MeuGestorFinanceiro.Repositories;

namespace MeuGestorFinanceiro.Services
{
    public class BalancoFinanceiroService
    {
        private BalancoFinanceiroDTO balanco = new BalancoFinanceiroDTO();
        public BalancoFinanceiroDTO Balanco { get { return balanco; } }
        public BalancoFinanceiroService()
        {
            balanco.TotalDespesa = new DespesaRepository().PegarValorTotal();
            balanco.TotalReceita = new ReceitaRepository().PegarValorTotal();
        }
    }

    public class BalancoFinanceiroDTO
    {
        public decimal Saldo { get { return (TotalReceita - TotalDespesa); } }
        public decimal TotalDespesa { get; set; }
        public decimal TotalReceita { get; set; }
    }
}
