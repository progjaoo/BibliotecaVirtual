using BibliotecaVirtual.Core.Entidades;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaVirtual.Infrastructure.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly BibliotecaVirtualContext _dbcontext;

        public CategoriaRepositorio(BibliotecaVirtualContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Categoria categoria)
        {
            await _dbcontext.AddAsync(categoria);
        }

        public async Task<Categoria> BuscarPorId(int id)
        {
            return await _dbcontext.Categoria.SingleOrDefaultAsync(c => c.Id == id);   
        }

        public async Task<List<Categoria>> BuscarTodas(string query)
        {
            var categoria = await _dbcontext.Categoria.ToListAsync();
            return categoria;
        }

        public async Task Deletar(int id)
        {
            var obj = await _dbcontext.Categoria.SingleOrDefaultAsync(c => c.Id == id);

            if (obj == null)
                throw new Exception("A categoria nao existe");
            await RemoverAsync(obj);
        }

        public async Task RemoverAsync(Categoria categoria)
        {
            _dbcontext.Remove(categoria);
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
