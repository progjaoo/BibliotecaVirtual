using BibliotecaVirtual.Core.Enums;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;

namespace BibliotecaVirtual.Application.Commands.Emprestimo.AdicionarEmprestimo
{
    public class AddEmprestimoCommandHandler : IRequestHandler<AddEmprestimoCommand, Unit>
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;

        public AddEmprestimoCommandHandler(IEmprestimoRepositorio emprestimoRepositorio)
        {
            _emprestimoRepositorio = emprestimoRepositorio;
        }

        public async Task<Unit> Handle(AddEmprestimoCommand request, CancellationToken cancellationToken)
        {

            var emprestimo = new Core.Entidades.Emprestimo(request.IdLivro, request.IdUsuario, request.DataEmprestimo, request.DataDevolucao);

            await _emprestimoRepositorio.AddAsync(emprestimo);

            await _emprestimoRepositorio.SaveChangesAsync();

            await _emprestimoRepositorio.AtualizarStatusEmprestimo(emprestimo.Id, StatusEmprestimoEnum.Emprestado);

            return Unit.Value;
        }
    }
}
