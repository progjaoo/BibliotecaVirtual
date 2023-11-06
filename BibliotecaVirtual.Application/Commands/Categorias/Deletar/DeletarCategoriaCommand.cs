using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Categorias.Deletar
{
    public class DeletarCategoriaCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeletarCategoriaCommand(int id)
        {
            Id = id;
        }
    }
}
