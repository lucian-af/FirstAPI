using ApiWeb.Data.Map.Produto;
using ApiWeb.Models.Produto;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Data
{
    public class StoreDataContext : DbContext
    {
        #region Mapeamentos
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        #endregion

        #region ConectionString
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=ApiWeb;User ID=sa;Password=sql@2017");
        }
        #endregion

        #region ModelCreating
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoriaMap());
            builder.ApplyConfiguration(new ProdutoMap());
        }
        #endregion
    }
}
