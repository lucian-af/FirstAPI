using System.Collections.Generic;
using System.Linq;
using ApiWeb.Data;
using ApiWeb.Models.Produto;
using ApiWeb.ViewModels.Produto;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Repositorios.Produto
{
    public class CategoriaRepositorio
    {
        private readonly StoreDataContext _context;

        #region Constructor
        public CategoriaRepositorio(StoreDataContext context)
        {
            _context = context;
        }
        #endregion

        #region Crud
        public void Save(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public void Update(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public void Delete(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }
        #endregion

        #region View
        public Categoria Get(int Id)
        {
            return _context.Categorias.First(categoria => categoria.Id == Id);
        }
        public IEnumerable<lstCategoriaViewModel> GetAll()
        {
            return _context.Categorias
                .Select(categoria => new lstCategoriaViewModel
                {
                    Id = categoria.Id,
                    Titulo = categoria.Titulo
                }
                ).AsNoTracking().ToList();
        }
        public IEnumerable<lstProdutoViewModel> GetAllProdutosPorCategoria(int Id)
        {
            return _context.Produtos.Where(produto => produto.CategoriaId == Id)
                .Include(produto => produto.Categoria)
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
        #endregion
    }
}
