using MeuGestorFinanceiro.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuGestorFinanceiro.Maps
{
    public class CategoriaMap : IEntityTypeConfiguration<CategoriaDomain>
    {
        public void Configure(EntityTypeBuilder<CategoriaDomain> builder)
        {
            builder.ToTable("categoria");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").UseIdentityColumn();
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(50).IsRequired();
        }
    }
}
