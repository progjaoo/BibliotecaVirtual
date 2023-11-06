using System.ComponentModel.DataAnnotations;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Categorias.Atualizar
{
    public class AtualizarCategoriaCommandHandler : IRequestHandler<AtualizarCategoriaCommand, Unit>
    {

        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public AtualizarCategoriaCommandHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<Unit> Handle(AtualizarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var atualizar = await _categoriaRepositorio.BuscarPorId(request.Id);

            atualizar.Update(request.Nome);   //arrumar atualizar Livro
             
            await _categoriaRepositorio.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
