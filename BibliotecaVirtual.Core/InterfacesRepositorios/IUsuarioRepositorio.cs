using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.Entidades;

namespace BibliotecaVirtual.Core.InterfacesRepositorios
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> BuscarTodos(string query);
        Task<Usuario>BuscarPorId(int id);
        Task<Usuario> BuscarPorEmaileSenha(string email, string senhaHash);
        Task Deletar(int id);
        Task SaveChangesAsync();
    }
}
