using BibliotecaVirtual.Core.Entidades;

namespace BibliotecaVirtual.Core.InterfacesRepositorios
{
    public interface ILivroRepositorio
    {
        Task<List<Livro>>BuscarTodos(string query);
        Task<Livro>BuscarPorId(int id);
        Task AddAsync(Livro livro);
        Task Deletar(int id);
        Task FinalizarLeitura(int id);
        Task SaveChangesAsync();
    }
}