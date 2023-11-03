using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Livros.Atualizar
{
    public class AtualizarLivroCommandoHandler : IRequestHandler<AtualizarLivroCommand, Unit>
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public AtualizarLivroCommandoHandler(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public async Task<Unit> Handle(AtualizarLivroCommand request, CancellationToken cancellationToken)
        {
            
            var livro = await _livroRepositorio.BuscarPorId(request.Id);

            livro.Update(request.Id, request.Titulo, request.Autor, request.AnoPublicacao, request.Descricao);

            await _livroRepositorio.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
