using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using BibliotecaVirtual.Core.Entidades;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.Categorias.BuscarTodas
{
    public class BuscarTodasCategoriasQueryHandler : IRequestHandler<BuscarTodasCategoriasQuery, List<CategoriaViewModel>>
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public BuscarTodasCategoriasQueryHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<List<CategoriaViewModel>> Handle(BuscarTodasCategoriasQuery request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepositorio.BuscarTodas(request.Query);

            var categoriaViewModel = categoria.Select(c => new CategoriaViewModel(c.Id, c.Nome)).ToList();

            return categoriaViewModel;
        }
    }
}
