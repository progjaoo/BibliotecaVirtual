using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.LivroComentario.DeletarComentario
{
    public class DeletarComentarioCommand : IRequest<Unit>
    {
        public DeletarComentarioCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
