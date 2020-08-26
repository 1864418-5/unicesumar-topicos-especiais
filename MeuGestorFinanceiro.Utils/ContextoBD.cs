using Microsoft.EntityFrameworkCore;
using MeuGestorFinanceiro.Domains;
using MeuGestorFinanceiro.Maps;

namespace MeuGestorFinanceiro.Utils
{
    public class ContextoBD : DbContext
    {
        public DbSet<DespesaDomain> Despesas { get; set; }
        public DbSet<ReceitaDomain> Receitas { get; set; }
        public DbSet<CategoriaDomain> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-RPIOV9V\SERVIDORHELP; Initial Catalog=gt_financeiro; Integrated Security=SSPI");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DespesaMap());
            modelBuilder.ApplyConfiguration(new ReceitaMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
        }
    }
}
