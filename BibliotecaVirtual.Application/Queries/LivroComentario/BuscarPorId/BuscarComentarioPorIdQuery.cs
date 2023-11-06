using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.LivroComentario.BuscarPorId
{
    public class BuscarComentarioPorIdQuery : IRequest<ComentariosViewModel>
    {
        public int Id { get; set; }

        public BuscarComentarioPorIdQuery(int id)
        {
            Id = id;
        }
    }
}
