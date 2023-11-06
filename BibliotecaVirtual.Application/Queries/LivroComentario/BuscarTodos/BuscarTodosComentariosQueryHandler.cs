using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.LivroComentario.BuscarTodos
{
    public class BuscarTodosComentariosQueryHandler : IRequestHandler<BuscarTodosComentariosQuery, List<ComentariosViewModel>>
    {
        private readonly ILivroComentarioRepositorio _livroComentarioRepositorio;

        public BuscarTodosComentariosQueryHandler(ILivroComentarioRepositorio livroComentarioRepositorio)
        {
            _livroComentarioRepositorio = livroComentarioRepositorio;
        }

        public async Task<List<ComentariosViewModel>> Handle(BuscarTodosComentariosQuery request, CancellationToken cancellationToken)
        {
            var coment = await _livroComentarioRepositorio.BuscarTodosComentariosPorLivro(request.IdLivro);

            var commentViewModel = coment
                .Select(p => new ComentariosViewModel(p.Id, p.IdUsuario,
                new UsuarioViewModel(p.IdUsuarioNavigation.NomeCompleto, p.IdUsuarioNavigation.Email, p.IdUsuarioNavigation.Id),
                p.Conteudo, p.CriadoEm))
                .ToList();

            return commentViewModel;
        }
    }
}
