using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.LivroComentario.DeletarComentario
{
    public class DeletarComentarioCommandHandler : IRequestHandler<DeletarComentarioCommand, Unit>
    {
        private readonly ILivroComentarioRepositorio _livroComentarioRepositorio;

        public DeletarComentarioCommandHandler(ILivroComentarioRepositorio livroComentarioRepositorio)
        {
            _livroComentarioRepositorio = livroComentarioRepositorio;
        }

        public async Task<Unit> Handle(DeletarComentarioCommand request, CancellationToken cancellationToken)
        {
            var comentario = await _livroComentarioRepositorio.BuscarPorId(request.Id);

            await _livroComentarioRepositorio.Deletar(comentario.Id);
            await _livroComentarioRepositorio.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
