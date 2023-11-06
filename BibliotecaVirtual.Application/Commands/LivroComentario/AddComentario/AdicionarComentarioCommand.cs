using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.LivroComentario.AddComentario
{
    public class AdicionarComentarioCommand : IRequest<Unit>
    {
        public int IdUsuario { get; set; }

        public int IdLivro { get; set; }

        public string Conteudo { get; set; }
    }
}
