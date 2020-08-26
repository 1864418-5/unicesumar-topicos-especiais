using MeuGestorFinanceiro.Domains;
using MeuGestorFinanceiro.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MeuGestorFinanceiro.Repositories
{
    public class ReceitaRepository
    {
        public void Salvar(ReceitaDomain receita)
        {
            using (var contexto = new ContextoBD())
            {
                if (receita.Id > 0)
                {
                    contexto.Receitas.Attach(receita);
                    contexto.Entry(receita).State = EntityState.Modified;
                }
                else
                {
                    contexto.Receitas.Add(receita);
                }
                contexto.SaveChanges();
            }
        }

        public List<ReceitaDomain> Listar()
        {
            using (var contexto = new ContextoBD())
            {
                return contexto.Receitas.ToList();
            }
        }

        public List<ReceitaDomain> Listar(bool recebido)
        {
            using (var contexto = new ContextoBD())
            {
                return contexto.Receitas.Where(x => x.Recebido == recebido).ToList();
            }
        }

        public void Deletar(int id)
        {
            using (var contexto = new ContextoBD())
            {
                var receita = contexto.Receitas.First(x => x.Id == id);
                contexto.Receitas.Remove(receita);
                contexto.SaveChanges();
            }
        }

        public decimal PegarValorTotal()
        {
            using (var contexto = new ContextoBD())
            {
                return contexto.Receitas.Where(x => x.Recebido).Sum(x => x.Valor);
            }
        }
    }
}
