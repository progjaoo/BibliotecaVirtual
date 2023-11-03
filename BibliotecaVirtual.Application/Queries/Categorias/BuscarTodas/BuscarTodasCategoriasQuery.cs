using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using BibliotecaVirtual.Core.Entidades;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.Categorias.BuscarTodas
{
    public class BuscarTodasCategoriasQuery : IRequest<List<CategoriaViewModel>>
    {
        public string Query { get; set; }
    }
}
