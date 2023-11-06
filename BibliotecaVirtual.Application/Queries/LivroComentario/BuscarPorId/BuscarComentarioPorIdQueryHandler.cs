using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.LivroComentario.BuscarPorId
{
    public class BuscarComentarioPorIdQueryHandler : IRequestHandler<BuscarComentarioPorIdQuery, ComentariosViewModel>
    {
        private readonly ILivroComentarioRepositorio _livroComentarioRepositorio;

        public BuscarComentarioPorIdQueryHandler(ILivroComentarioRepositorio livroComentarioRepositorio)
        {
            _livroComentarioRepositorio = livroComentarioRepositorio;
        }

        public async Task<ComentariosViewModel> Handle(BuscarComentarioPorIdQuery request, CancellationToken cancellationToken)
        {
            var coment = await _livroComentarioRepositorio.BuscarPorId(request.Id);

            if (coment == null) return null;

            var comentarioViewModel = new ComentariosViewModel(coment.Id, coment.IdUsuario, coment.Conteudo, coment.CriadoEm);

            return comentarioViewModel;
        }
    }
}
