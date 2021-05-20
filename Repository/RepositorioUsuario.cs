using apiCadastroProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCadastroProduto.Repository
{
    public class RepositorioUsuario : RepositorioGenerico<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(AppDbContext repositorioContext)
            : base(repositorioContext)
        {
        }
    }
}
