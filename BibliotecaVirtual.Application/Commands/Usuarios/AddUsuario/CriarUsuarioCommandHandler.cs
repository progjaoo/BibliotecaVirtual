using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.Entidades;
using BibliotecaVirtual.Core.InterfaceService;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Usuarios.AddUsuario
{
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, int>
    {
        private readonly IServicoAutenticacao _servicoAutenticacao;
        private readonly BibliotecaVirtualContext _dbcontext;

        public CriarUsuarioCommandHandler(IServicoAutenticacao servicoAutenticacao, BibliotecaVirtualContext dbcontext)
        {
            _servicoAutenticacao = servicoAutenticacao;
            _dbcontext = dbcontext;
        }

        public async Task<int> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var senhaHash = _servicoAutenticacao.ComputarHashSha256(request.Senha);

            var usuario = new Usuario(request.NomeCompleto, request.Email, request.DataNasc, senhaHash);

            await _dbcontext.Usuario.AddAsync(usuario);
            await _dbcontext.SaveChangesAsync();

            return usuario.Id;
        }
    }
}
