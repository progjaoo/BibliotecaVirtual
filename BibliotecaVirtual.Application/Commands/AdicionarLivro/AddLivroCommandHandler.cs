using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.Entidades;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.AdicionarLivro
{
    public class AddLivroCommandHandler : IRequestHandler<AddLivroCommand, int>
    {
        private readonly ILivroRepositorio _livroRepositorio;
        private readonly IUsuarioLivroRepositorio _usuarioLivroRepositorio;

        public AddLivroCommandHandler(ILivroRepositorio livroRepositorio, IUsuarioLivroRepositorio usuarioLivroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
            _usuarioLivroRepositorio = usuarioLivroRepositorio;
        }

        public async Task<int> Handle(AddLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = new Livro(request.IdCategoria, request.Titulo, request.Autor, request.AnoPublicacao, request.Descricao);

            await _livroRepositorio.AddAsync(livro);
            await _livroRepositorio.SaveChangesAsync();

            var usuariolivro = new UsuarioLivro(livro.Id, request.IdUsuario);

            await _usuarioLivroRepositorio.AddAsync(usuariolivro);
            await _usuarioLivroRepositorio.SaveChangesAsync();

            return livro.Id;
        }
    }
}
