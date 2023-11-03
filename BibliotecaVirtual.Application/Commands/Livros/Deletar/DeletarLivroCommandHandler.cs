using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Livros.Deletar
{
    public class DeleteLivroCommandHandler : IRequestHandler<DeletarLivroCommand, Unit>
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public DeleteLivroCommandHandler(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public async Task<Unit> Handle(DeletarLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = await _livroRepositorio.BuscarPorId(request.Id);

            await _livroRepositorio.Deletar(livro.Id);

            await _livroRepositorio.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
