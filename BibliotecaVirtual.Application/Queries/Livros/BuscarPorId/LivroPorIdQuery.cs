using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.Livro.BuscarPorId
{
    public class LivroPorIdQuery : IRequest<LivroViewModel>
    {
        public LivroPorIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
