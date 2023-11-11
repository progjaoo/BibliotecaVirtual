using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Emprestimo.AdicionarEmprestimo
{
    public class AddEmprestimoCommand : IRequest<Unit>
    {
        public int IdLivro { get; set; }

        public int IdUsuario { get; set; }

        public DateTime DataEmprestimo { get; set; }

        public DateTime DataDevolucao { get; set; }
    }
}
