using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.LivroComentario.AtualizarComentario
{
    public class AtualizarComentarioCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public string Conteudo { get; set; }
    }
}
