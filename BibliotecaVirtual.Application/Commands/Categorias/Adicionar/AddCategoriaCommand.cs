using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Categorias.Adicionar
{
    public class AddCategoriaCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
