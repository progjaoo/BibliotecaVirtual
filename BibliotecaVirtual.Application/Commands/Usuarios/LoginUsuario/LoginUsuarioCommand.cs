using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Usuarios.LoginUsuario
{
    public class LoginUsuarioCommand : IRequest<LoginUsuarioViewModel>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
