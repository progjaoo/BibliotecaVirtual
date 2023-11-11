using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.Entidades;
using BibliotecaVirtual.Core.Enums;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaVirtual.Infrastructure.Repositorios
{
    public class EmprestimoRepositorio : IEmprestimoRepositorio
    {
        private readonly BibliotecaVirtualContext _dbcontext;

        public EmprestimoRepositorio(BibliotecaVirtualContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Emprestimo> BuscarPorId(int id)
        {
            return await _dbcontext.Emprestimo.SingleOrDefaultAsync(e => e.Id == id);

            //.Include(e => e.IdLivroNavigation).ThenInclude(livro => livro.StatusEmprestimo).
        }

        public async Task<List<Emprestimo>> BuscarTodos(string query)
        {
            return await _dbcontext.Emprestimo.ToListAsync();
        }

        public async Task AddAsync(Emprestimo emprestimo)
        {
            await _dbcontext.Emprestimo.AddAsync(emprestimo);
        }

        public async Task AtualizarStatusEmprestimo(int idEmprestimo, StatusEmprestimoEnum novoStatus)
        {
            var emprestimo = await _dbcontext.Emprestimo
                        .Include(e => e.IdLivroNavigation)
                        .SingleOrDefaultAsync(e => e.Id == idEmprestimo);

            if (emprestimo != null)
            {
                emprestimo.IdLivroNavigation.StatusEmprestimo = novoStatus;
            }
            else
            {
                Console.WriteLine($"Emprestimo com ID {idEmprestimo} não encontrado.");
            }

            await _dbcontext.SaveChangesAsync();
        }
        
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
