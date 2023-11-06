using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.Usuarios.BuscarPorId
{
    public class BuscarUsuarioPorIdQueryHandler : IRequestHandler<BuscarUsuarioPorIdQuery, UsuarioViewModel>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public BuscarUsuarioPorIdQueryHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<UsuarioViewModel> Handle(BuscarUsuarioPorIdQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepositorio.BuscarPorId(request.Id);

            if (usuario == null) return null;

            var usuarioViewModel = new UsuarioViewModel(usuario.NomeCompleto, usuario.Email);

            return usuarioViewModel;
        }
    }
}
