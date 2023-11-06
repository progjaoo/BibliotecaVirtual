using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Usuarios.AddUsuario
{
    public class CriarUsuarioCommand : IRequest<int>
    {
        public string NomeCompleto { get; set; }

        public string Email { get; set; }

        public DateTime? DataNasc { get; set; }

        public string Senha { get; set; }

/*        public string Papel { get; set; } = "Usuario";
*/    }
}
