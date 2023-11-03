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
    public class UsuarioLivroRepositorio : IUsuarioLivroRepositorio
    {
        private readonly BibliotecaVirtualContext _dbcontext;

        public UsuarioLivroRepositorio(BibliotecaVirtualContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(UsuarioLivro usuarioLivro)
        {
            await _dbcontext.UsuarioLivro.AddAsync(usuarioLivro);
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
