using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.Livro.BuscarTodos
{
    public class BuscarTodosQueryHandler : IRequestHandler<BuscarTodosQuery, List<LivroViewModel>>
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public BuscarTodosQueryHandler(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public async Task<List<LivroViewModel>> Handle(BuscarTodosQuery request, CancellationToken cancellationToken)
        {
            var livro = await _livroRepositorio.BuscarTodos(request.Query);

            var livroViewModel = livro.Select(l => new LivroViewModel(
                l.Id, l.Titulo, l.Descricao, l.Autor)).ToList();

            return livroViewModel;
        }
    }
}
