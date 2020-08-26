using MeuGestorFinanceiro.Domains;
using MeuGestorFinanceiro.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MeuGestorFinanceiro.Repositories
{
    public class CategoriaRepository
    {
        public void Salvar(CategoriaDomain categoria)
        {
            using (var contexto = new ContextoBD())
            {
                if (categoria.Id > 0)
                {
                    contexto.Categorias.Attach(categoria);
                    contexto.Entry(categoria).State = EntityState.Modified;
                }
                else
                {
                    contexto.Categorias.Add(categoria);
                }
                contexto.SaveChanges();
            }
        }

        public List<CategoriaDomain> Listar()
        {
            using (var contexto = new ContextoBD())
            {
                return contexto.Categorias.ToList();
            }
        }

        public bool VerificarExistenciaCategoria(int idCategoria)
        {
            using (var contexto = new ContextoBD())
            {
                return contexto.Categorias.Any(x => x.Id == idCategoria);
            }
        }
    }
}

