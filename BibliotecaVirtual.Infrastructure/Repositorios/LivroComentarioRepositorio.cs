using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.Entidades;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaVirtual.Infrastructure.Repositorios
{
    public class LivroComentarioRepositorio : ILivroComentarioRepositorio
    {
        private readonly BibliotecaVirtualContext _dbcontext;

        public LivroComentarioRepositorio(BibliotecaVirtualContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(LivroComentario comentario)
        {
            await _dbcontext.LivroComentario.AddAsync(comentario);
        }

        public async Task<LivroComentario> BuscarPorId(int id)
        {
            return await _dbcontext.LivroComentario.SingleOrDefaultAsync(l => l.Id == id);
        }
        public async Task<List<LivroComentario>> BuscarTodosComentariosPorLivro(int IdLivro)
        {
            return await _dbcontext.LivroComentario.Where(c => c.IdLivro == IdLivro)
            .Include(c => c.IdUsuarioNavigation)
            .ToListAsync();
        }
        public async Task<List<LivroComentario>> BuscarTodos(string query)
        {
            return await _dbcontext.LivroComentario.ToListAsync();
        }
        public async Task RemoverAsync(LivroComentario comentario)
        {
            _dbcontext.Remove(comentario);
        }
        public async Task Deletar(int id)
        {
            var obj = await _dbcontext.LivroComentario.SingleOrDefaultAsync(l => l.Id == id);

            if (obj == null)
                throw new Exception("O Comentario nao existe");
            await RemoverAsync(obj);
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
