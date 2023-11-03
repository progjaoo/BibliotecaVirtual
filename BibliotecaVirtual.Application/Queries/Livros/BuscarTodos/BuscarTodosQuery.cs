using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.Livro.BuscarTodos
{
    public class BuscarTodosQuery : IRequest <List<LivroViewModel>>
    {
        public string Query { get; set; }
    }
}
