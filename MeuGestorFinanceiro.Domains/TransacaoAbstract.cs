using System;

namespace MeuGestorFinanceiro.Domains
{
    public abstract class TransacaoAbstract
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int IdCategoria { get; set; }
    }
}
