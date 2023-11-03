using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Livros.Atualizar
{
    public class AtualizarLivroCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public DateTime? AnoPublicacao { get; set; }

        public string Descricao { get; set; }
    }
}
