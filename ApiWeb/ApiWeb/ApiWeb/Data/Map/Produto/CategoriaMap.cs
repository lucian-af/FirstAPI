using ApiWeb.Models.Produto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiWeb.Data.Map.Produto
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(key => key.Id);
            builder.Property(prop => prop.Titulo)
                .IsRequired()
                .HasMaxLength(120)
                .HasColumnType("varchar(120)");
        }
    }
}
