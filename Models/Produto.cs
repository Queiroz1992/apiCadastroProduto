using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCadastroProduto.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Titulo { get; set; }
        public double Preco { get; set; }
        public int Estoque { get; set; }
    }
}
