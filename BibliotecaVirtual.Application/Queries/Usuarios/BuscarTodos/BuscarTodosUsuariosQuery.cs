using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.Usuarios.BuscarTodos
{
    public class BuscarTodosUsuariosQuery : IRequest <List<UsuarioViewModel>>
    {
        public string Query { get; set; }
    }
}
