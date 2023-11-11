using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.Emprestimo.BuscarTodos
{
    public class BuscarTodosEmprestimosQueryHandler : IRequestHandler<BuscarTodosEmprestimosQuery, List<EmprestimoViewModel>>
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;

        public BuscarTodosEmprestimosQueryHandler(IEmprestimoRepositorio emprestimoRepositorio)
        {
            _emprestimoRepositorio = emprestimoRepositorio;
        }

        public async Task<List<EmprestimoViewModel>> Handle(BuscarTodosEmprestimosQuery request, CancellationToken cancellationToken)
        {
            var emprestimo = await _emprestimoRepositorio.BuscarTodos(request.Query);

            var emprestimoViewModel = emprestimo.Select(e => new EmprestimoViewModel(
                e.IdLivro, e.IdUsuario, e.DataEmprestimo, e.DataDevolucao)).ToList();

            return emprestimoViewModel;
        }
    }
}
