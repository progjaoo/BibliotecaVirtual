using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.LivroPorIdQuery
{
    public class LivroPorIdQueryHandler : IRequestHandler<LivroPorIdQuery, LivroViewModel>
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroPorIdQueryHandler(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public async Task<LivroViewModel> Handle(LivroPorIdQuery request, CancellationToken cancellationToken)
        {
            var livro = await _livroRepositorio.BuscarPorId(request.Id);

            if (livro == null) return null;

            var livroViewModel = new LivroViewModel(livro.Id, livro.Titulo, livro.Autor);
            
            return livroViewModel;
        }
    }
}
