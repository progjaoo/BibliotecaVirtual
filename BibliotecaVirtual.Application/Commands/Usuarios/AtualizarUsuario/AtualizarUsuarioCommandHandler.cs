using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.InterfaceService;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;
using Microsoft.Identity.Client;

namespace BibliotecaVirtual.Application.Commands.Usuarios.AtualizarUsuario
{
    public class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IServicoAutenticacao _servicoAutenticacao;
        public AtualizarUsuarioCommandHandler(IUsuarioRepositorio usuarioRepositorio, IServicoAutenticacao servicoAutenticacao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _servicoAutenticacao = servicoAutenticacao;
        }
        public async Task<Unit> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepositorio.BuscarPorId(request.Id);
            var senhaHash = _servicoAutenticacao.ComputarHashSha256(request.Senha);

            usuario.Update(request.NomeCompleto, senhaHash);

            await _usuarioRepositorio.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
