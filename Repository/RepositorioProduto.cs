using apiCadastroProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCadastroProduto.Repository
{
    public class RepositorioProduto : RepositorioGenerico<Produto>, IRepositorioProduto
    {
        public RepositorioProduto(AppDbContext repositorioContext)
             : base(repositorioContext)
        {
        }
    }
}
