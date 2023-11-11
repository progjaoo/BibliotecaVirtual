using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using BibliotecaVirtual.Core.Entidades;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaVirtual.Infrastructure.Repositorios
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly BibliotecaVirtualContext _dbcontext;

        public LivroRepositorio(BibliotecaVirtualContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Livro> BuscarPorId(int id)
        {
            return await _dbcontext.Livro.SingleOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Livro>> BuscarTodos(string query)
        {
            return await _dbcontext.Livro.ToListAsync();
        }

        public async Task AddAsync(Livro livro)
        {
            await _dbcontext.AddAsync(livro);
        }

        public async Task FinalizarLeitura(int id)
        {
            var livro = await _dbcontext.Livro.SingleOrDefaultAsync(l => l.Id == id);

            livro.Lido();
        }
        public async Task Deletar(int id)
        {
            var obj = await _dbcontext.Livro.SingleOrDefaultAsync(l => l.Id == id);

            if (obj == null)
                throw new Exception("O Livro nao existe");
            await RemoverAsync(obj);
        }
        public async Task RemoverAsync(Livro livro)
        {
            _dbcontext.Remove(livro);
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
