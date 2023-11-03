using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.Entidades;

namespace BibliotecaVirtual.Core.InterfacesRepositorios
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> BuscarTodas(string query);
        Task<Categoria> BuscarPorId(int id);
        Task AddAsync(Categoria categoria);
        Task Deletar(int id);
        Task SaveChangesAsync();
    }
}
