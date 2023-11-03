using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Livros.Deletar
{
    public class DeletarLivroCommand : IRequest<Unit>
    {
        public DeletarLivroCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
