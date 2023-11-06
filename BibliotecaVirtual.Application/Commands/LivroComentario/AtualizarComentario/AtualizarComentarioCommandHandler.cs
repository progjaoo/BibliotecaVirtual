using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.LivroComentario.AtualizarComentario
{
    public class AtualizarComentarioCommandHandler : IRequestHandler<AtualizarComentarioCommand, Unit>
    {
        private readonly ILivroComentarioRepositorio _livroComentarioRepositorio;

        public AtualizarComentarioCommandHandler(ILivroComentarioRepositorio livroComentarioRepositorio)
        {
            _livroComentarioRepositorio = livroComentarioRepositorio;
        }
        public async Task<Unit> Handle(AtualizarComentarioCommand request, CancellationToken cancellationToken)
        {
            var comentario = await _livroComentarioRepositorio.BuscarPorId(request.Id);

            comentario.Update(request.Conteudo);

            await _livroComentarioRepositorio.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
