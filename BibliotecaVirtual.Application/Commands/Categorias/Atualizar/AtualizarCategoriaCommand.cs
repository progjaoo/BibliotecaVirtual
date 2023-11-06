using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Categorias.Atualizar
{
    public class AtualizarCategoriaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
