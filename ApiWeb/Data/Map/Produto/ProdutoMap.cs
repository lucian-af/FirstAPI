using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiWeb.Data.Map.Produto
{
    public class ProdutoMap : IEntityTypeConfiguration<Models.Produto.Produto>
    {
        public void Configure(EntityTypeBuilder<Models.Produto.Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(key => key.Id);
            builder.Property(prop => prop.DataCriacao).IsRequired();
            builder.Property(prop => prop.Descricao).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
            builder.Property(prop => prop.CaminhoImagem).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
            builder.Property(prop => prop.DataAlteracao).IsRequired();
            builder.Property(prop => prop.Preco).IsRequired().HasColumnType("decimal(12,2)");
            builder.Property(prop => prop.Quantidade).IsRequired();
            builder.Property(prop => prop.Titulo).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.HasOne(prop => prop.Categoria).WithMany(categoria => categoria.Produtos);
        }
    }
}
