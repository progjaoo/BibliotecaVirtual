using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Categorias.Deletar
{
    public class DeletarCategoriaCommandHandler : IRequestHandler<DeletarCategoriaCommand, Unit>
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public DeletarCategoriaCommandHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<Unit> Handle(DeletarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var deletar = await _categoriaRepositorio.BuscarPorId(request.Id);

            await _categoriaRepositorio.Deletar(deletar.Id);
            await _categoriaRepositorio.SaveChangesAsync();

            return Unit.Value; 
        }
    }
}
