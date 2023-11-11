using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.Entidades;
using BibliotecaVirtual.Core.Enums;

namespace BibliotecaVirtual.Core.InterfacesRepositorios
{
    public interface IEmprestimoRepositorio
    {
        Task<List<Emprestimo>> BuscarTodos(string query);
        Task<Emprestimo> BuscarPorId(int id);
        Task AddAsync(Emprestimo emprestimo);
        Task AtualizarStatusEmprestimo(int idEmprestimo, StatusEmprestimoEnum novoStatus);
        Task SaveChangesAsync();
    }
}
