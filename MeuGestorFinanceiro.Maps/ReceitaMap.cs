using MeuGestorFinanceiro.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuGestorFinanceiro.Maps
{
    public class ReceitaMap : IEntityTypeConfiguration<ReceitaDomain>
    {
        public void Configure(EntityTypeBuilder<ReceitaDomain> builder)
        {
            builder.ToTable("receita");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn();
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(100).IsRequired();
            builder.Property(x => x.IdCategoria).HasColumnName("id_categoria").IsRequired();
            builder.HasOne(x => x.Categoria).WithMany(x => x.Receitas).HasForeignKey(x => x.IdCategoria).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
