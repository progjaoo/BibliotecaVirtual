using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.Emprestimo.BuscarTodos
{
    public class BuscarTodosEmprestimosQuery : IRequest<List<EmprestimoViewModel>>
    {
        public string Query { get; set; }
    }
}
