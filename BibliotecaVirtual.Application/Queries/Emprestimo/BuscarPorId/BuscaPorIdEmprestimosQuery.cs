using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.Emprestimo.BuscarPorId
{
    public class BuscaPorIdEmprestimosQuery : IRequest<EmprestimoViewModel>
    {
        public BuscaPorIdEmprestimosQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
