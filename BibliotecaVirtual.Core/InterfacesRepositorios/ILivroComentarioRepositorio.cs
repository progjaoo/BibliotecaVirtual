using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.Entidades;

namespace BibliotecaVirtual.Core.InterfacesRepositorios
{
    public interface ILivroComentarioRepositorio
    {
        Task<List<LivroComentario>> BuscarTodos(string query);
        Task<LivroComentario> BuscarPorId(int id);
        Task<List<LivroComentario>> BuscarTodosComentariosPorLivro(int IdLivro);

        Task AddAsync(LivroComentario comentario);
        Task Deletar(int id);
        Task SaveChangesAsync();
    }
}
