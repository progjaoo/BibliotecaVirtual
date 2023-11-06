using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Usuarios.DeletarUsuario
{
    public class DeletarUsuarioCommandHandler : IRequestHandler<DeletarUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public DeletarUsuarioCommandHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<Unit> Handle(DeletarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepositorio.BuscarPorId(request.Id);

            await _usuarioRepositorio.Deletar(usuario.Id);
            await _usuarioRepositorio.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
