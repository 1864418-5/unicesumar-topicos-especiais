using MeuGestorFinanceiro.Domains;
using MeuGestorFinanceiro.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MeuGestorFinanceiro.Repositories
{
    public class DespesaRepository
    {
        public void Salvar(DespesaDomain despesa)
        {
            using(var contexto = new ContextoBD())
            {
                if(despesa.Id > 0)
                {
                    contexto.Despesas.Attach(despesa);
                    contexto.Entry(despesa).State = EntityState.Modified;
                }
                else
                {
                    contexto.Despesas.Add(despesa);
                }
                contexto.SaveChanges();
            }
        }

        public List<DespesaDomain> Listar()
        {
            using (var contexto = new ContextoBD())
            {
                return contexto.Despesas.ToList();
            }
        }

        public List<DespesaDomain> Listar(bool pago)
        {
            using (var contexto = new ContextoBD())
            {
                return contexto.Despesas.Where(x => x.Pago == pago).ToList();
            }
        }

        public void Deletar(int id)
        {
            using(var contexto = new ContextoBD())
            {
                var despesa = contexto.Despesas.First(x => x.Id == id);
                contexto.Despesas.Remove(despesa);
                contexto.SaveChanges();
            }
        }

        public decimal PegarValorTotal()
        {
            using(var contexto = new ContextoBD())
            {
                return contexto.Despesas.Where(x => x.Pago).Sum(x => x.Valor);
            }
        }
    }
}
