using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.LivroComentario.BuscarTodos
{
    public class BuscarTodosComentariosQuery : IRequest<List<ComentariosViewModel>>
    {
        public BuscarTodosComentariosQuery(int idLivro)
        {
            IdLivro = idLivro;
        }

        public int IdLivro { get; set; }
    }
}
