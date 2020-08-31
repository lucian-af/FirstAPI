using System.Collections.Generic;

namespace ApiWeb.Models.Produto
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
