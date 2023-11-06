using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Usuarios.DeletarUsuario
{
    public class DeletarUsuarioCommand : IRequest<Unit>
    {
        public DeletarUsuarioCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; } 
    }
}
