using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using BibliotecaVirtual.Core.InterfaceService;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;
using Microsoft.Identity.Client;

namespace BibliotecaVirtual.Application.Commands.Usuarios.LoginUsuario
{
    public class LoginUsuarioCommandHandler : IRequestHandler<LoginUsuarioCommand, LoginUsuarioViewModel>
    {
        private readonly IServicoAutenticacao _servicoAutenticacao;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginUsuarioCommandHandler(IServicoAutenticacao servicoAutenticacao, IUsuarioRepositorio usuarioRepositorio)
        {
            _servicoAutenticacao = servicoAutenticacao;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<LoginUsuarioViewModel> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
        {
            var senhaHash = _servicoAutenticacao.ComputarHashSha256(request.Senha);

            var usuario = await _usuarioRepositorio.BuscarPorEmaileSenha(request.Email, senhaHash);

            if(usuario == null) return null;

            var token = _servicoAutenticacao.GerarTokenJWT(usuario.Email, usuario.Papel);

            return new LoginUsuarioViewModel(usuario.Email, token);
        }
    }
}
