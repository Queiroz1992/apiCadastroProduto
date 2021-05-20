using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCadastroProduto.Repository
{
    public interface IRepositorioGenerico<T> where T : class
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(int id);
        Task Inserir(T obj);
        Task Atualizar(int id, T obj);
        Task Excluir(int id);
    }
}
