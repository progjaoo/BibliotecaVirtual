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
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BibliotecaVirtualContext _dbcontext;

        public UsuarioRepositorio(BibliotecaVirtualContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _dbcontext.Usuario.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Usuario>> BuscarTodos(string query)
        {
            return await _dbcontext.Usuario.ToListAsync();
        }
        public async Task<Usuario> BuscarPorEmaileSenha(string email, string senhaHash)
        {
            return await _dbcontext.Usuario.SingleOrDefaultAsync(u => u.Email == email && u.Senha == senhaHash);

        }
        public async Task Deletar(int id)
        {
            var obj = await _dbcontext.Usuario.SingleOrDefaultAsync(l => l.Id == id);

            if (obj == null)
                throw new Exception("O Usuario nao existe");
            await RemoverAsync(obj);
        }
        public async Task RemoverAsync(Usuario usuario)
        {
            _dbcontext.Remove(usuario);
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
