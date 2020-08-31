using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ApiWeb.Data;
using ApiWeb.Models.Produto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Controllers
{    
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly StoreDataContext _context;

        public CategoriaController(StoreDataContext context)
        {            
            _context = context;
        }

        #region HttpGet
        [Route("v1/categoria")]
        [HttpGet]
        public IEnumerable<Categoria> GetAll()
        {
            return _context.Categorias.AsNoTracking().ToList();
        }

        [Route("v1/categoria/{id}")]
        [HttpGet]
        public Categoria Get(int id)
        {
            return _context.Categorias.AsNoTracking().Where(categoria => categoria.Id == id)?.First();
        }

        [Route("v1/categoria/{id}/produtos")]
        [HttpGet]
        public IEnumerable<Produto> GetAllProdutos(int id)
        {
            return _context.Produtos.AsNoTracking().Where(produto => produto.CategoriaId == id)?.ToList();
        }
        #endregion

        #region HttpPost
        [Route("v1/categoria")]
        [HttpPost]
        public Categoria Post([FromBody] Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return categoria;
        }
        #endregion

        #region HttpPut
        [Route("v1/categoria")]
        [HttpPut]
        public Categoria Put([FromBody] Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return categoria;
        }
        #endregion

        #region HttpDelete
        [Route("v1/categoria")]
        [HttpDelete]
        public Categoria Delete([FromBody] Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return categoria;
        }
        #endregion
    }
}
