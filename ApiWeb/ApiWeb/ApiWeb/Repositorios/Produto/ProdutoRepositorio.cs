using System.Collections.Generic;
using System.Linq;
using ApiWeb.Data;
using ApiWeb.ViewModels.Produto;
using Microsoft.EntityFrameworkCore;
using Pro = ApiWeb.Models.Produto;

namespace ApiWeb.Repositorios.Produto
{
    public class ProdutoRepositorio
    {
        private readonly StoreDataContext _context;

        #region Constructor
        public ProdutoRepositorio(StoreDataContext context)
        {
            _context = context;
        }
        #endregion

        #region Crud
        public void Save(Pro.Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Update(Pro.Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Delete(Pro.Produto produto)
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }
        #endregion

        #region View
        public IEnumerable<lstProdutoViewModel> GetAll()
        {
            return _context.Produtos.Include(produto => produto.Categoria)
                .Select(produto => new lstProdutoViewModel
                {
                    Id = produto.Id,
                    Titulo = produto.Titulo,
                    Preco = produto.Preco,
                    CategoriaId = produto.CategoriaId,
                    Categoria = produto.Categoria.Titulo
                })
                .AsNoTracking().ToList();
        }

        public Pro.Produto Get(int Id)
        {
            return _context.Produtos.Include(produto => produto.Categoria).First(produto => produto.Id == Id);
        }
        #endregion
    }
}
