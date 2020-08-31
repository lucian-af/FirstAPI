using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWeb.Models.Produto;

namespace ApiWeb.ViewModels.Produto
{
    public class lstProdutoViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }        
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public string Categoria { get; set; }
    }
}
