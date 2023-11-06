using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Core.Entidades;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Categorias.Adicionar
{
    public class AddCategoriaCommandHandler : IRequestHandler<AddCategoriaCommand, int>
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public AddCategoriaCommandHandler(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<int> Handle(AddCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = new Categoria(request.Id, request.Nome);

            await _categoriaRepositorio.AddAsync(categoria);
            await _categoriaRepositorio.SaveChangesAsync();

            return categoria.Id;
        }
    }
}
