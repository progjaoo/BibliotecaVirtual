using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.Usuarios.BuscarTodos
{
    public class BuscarTodosUsuariosQueryHandler : IRequestHandler<BuscarTodosUsuariosQuery, List<UsuarioViewModel>>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public BuscarTodosUsuariosQueryHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task <List<UsuarioViewModel>> Handle(BuscarTodosUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepositorio.BuscarTodos(request.Query);

            var usuarioViewModel = usuario.Select(u => new UsuarioViewModel(
                u.NomeCompleto, u.Email)).ToList();

            return usuarioViewModel;
        }
    }
}
