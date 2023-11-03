using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.Categorias.BuscarPorId
{
    public class BuscarIdCategoriaQueryHandler : IRequestHandler<BuscarIdCategoriaQuery, CategoriaViewModel>
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public BuscarIdCategoriaQueryHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<CategoriaViewModel> Handle(BuscarIdCategoriaQuery request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepositorio.BuscarPorId(request.Id);

            if (categoria == null) return null;

            var categoriaViewModel = new CategoriaViewModel(categoria.Id, categoria.Nome);

            return categoriaViewModel;
        }
    }
}
