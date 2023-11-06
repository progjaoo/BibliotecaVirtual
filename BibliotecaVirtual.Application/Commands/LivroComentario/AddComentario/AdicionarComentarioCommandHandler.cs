using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.Entidades;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.LivroComentario.AddComentario
{
    public class AdicionarComentarioCommandHandler : IRequestHandler<AdicionarComentarioCommand, Unit>
    {
        private readonly ILivroComentarioRepositorio _livroComentarioRepositorio;

        public AdicionarComentarioCommandHandler(ILivroComentarioRepositorio livroComentarioRepositorio)
        {
            _livroComentarioRepositorio = livroComentarioRepositorio;
        }
        public async Task<Unit> Handle(AdicionarComentarioCommand request, CancellationToken cancellationToken)
        {
            var comentario = new Core.Entidades.LivroComentario(request.IdUsuario, request.IdLivro, request.Conteudo);

            await _livroComentarioRepositorio.AddAsync(comentario);
            await _livroComentarioRepositorio.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
