using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaVirtual.Application.ViewModel;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Queries.Emprestimo.BuscarPorId
{
    public class BuscaPorIdEmprestimosQueryHandler : IRequestHandler<BuscaPorIdEmprestimosQuery, EmprestimoViewModel>
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;

        public BuscaPorIdEmprestimosQueryHandler(IEmprestimoRepositorio emprestimoRepositorio)
        {
            _emprestimoRepositorio = emprestimoRepositorio;
        }

        public async Task<EmprestimoViewModel> Handle(BuscaPorIdEmprestimosQuery request, CancellationToken cancellationToken)
        {
            var buscarEmp = await _emprestimoRepositorio.BuscarPorId(request.Id);

            if (buscarEmp == null) return null;

            var emprestimoViewModel = new EmprestimoViewModel(buscarEmp.IdLivro, buscarEmp.IdUsuario, buscarEmp.DataEmprestimo, buscarEmp.DataDevolucao);

            return emprestimoViewModel;
        }
    }
}
