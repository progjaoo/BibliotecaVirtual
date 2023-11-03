using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.Entidades;

namespace BibliotecaVirtual.Core.InterfacesRepositorios
{
    public interface IUsuarioLivroRepositorio
    {
        Task AddAsync(UsuarioLivro usuarioLivro);
        Task SaveChangesAsync();
    }
}
