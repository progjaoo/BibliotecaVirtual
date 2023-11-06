using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Usuarios.AtualizarUsuario
{
    public class AtualizarUsuarioCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public string NomeCompleto { get; set; }

        public string Senha { get; set; }
    }
}
