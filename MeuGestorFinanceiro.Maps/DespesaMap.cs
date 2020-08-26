using MeuGestorFinanceiro.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuGestorFinanceiro.Maps
{
    public class DespesaMap : IEntityTypeConfiguration<DespesaDomain>
    {
        public void Configure(EntityTypeBuilder<DespesaDomain> builder)
        {
            builder.ToTable("despesa");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn();
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(100).IsRequired();
            builder.Property(x => x.IdCategoria).HasColumnName("id_categoria").IsRequired();
            builder.HasOne(x => x.Categoria).WithMany(x => x.Despesas).HasForeignKey(x => x.IdCategoria).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
