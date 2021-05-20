using apiCadastroProduto.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiCadastroProduto.Repository
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private AppDbContext context = null;

        public RepositorioGenerico(AppDbContext _context)
        {
            context = _context;
        }

        public async Task Atualizar(int id, T obj)
        {
            context.Set<T>().Update(obj);
            await context.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var entidade = await ObterPorId(id);
            context.Set<T>().Remove(entidade);
            await context.SaveChangesAsync();
        }

        public async Task Inserir(T obj)
        {
            await context.Set<T>().AddAsync(obj);
            await context.SaveChangesAsync();
        }

        public async Task<T> ObterPorId(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> ObterTodos()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }
    }
}
