using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using BibliotecaVirtual.Core.Entidades;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.Categorias.BuscarPorId
{
    public class BuscarIdCategoriaQuery : IRequest<CategoriaViewModel>
    {

        public BuscarIdCategoriaQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

    }
}
