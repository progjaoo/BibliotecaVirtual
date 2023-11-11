using BibliotecaVirtual.Application.Commands.Emprestimo.AdicionarEmprestimo;
using BibliotecaVirtual.Application.Queries.Emprestimo.BuscarPorId;
using BibliotecaVirtual.Application.Queries.Emprestimo.BuscarTodos;
using BibliotecaVirtual.Application.Queries.LivroComentario.BuscarPorId;
using BibliotecaVirtual.Core.Entidades;
using BibliotecaVirtual.Core.Enums;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaVirtual.API.Controllers
{
    [Route("api/emprestimos")]
    public class EmprestimoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;

        public EmprestimoController(IMediator mediator, IEmprestimoRepositorio emprestimoRepositorio)
        {
            _mediator = mediator;
            _emprestimoRepositorio = emprestimoRepositorio;
        }
        [HttpGet]
        public async Task<IActionResult> BuscarTodos()
        {
            var buscaEmprestimo = new BuscarTodosEmprestimosQuery();

            var emprestimos = await _mediator.Send(buscaEmprestimo);

            return Ok(emprestimos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var buscaEmprestimoId = new BuscaPorIdEmprestimosQuery(id);

            var emprestimoId = await _mediator.Send(buscaEmprestimoId);

            return Ok(emprestimoId);
        }
        [HttpPost("emprestar")]
        public async Task <IActionResult> EmprestarLivro([FromBody] AddEmprestimoCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(BuscarPorId), new {id = id}, command);
        }
        [HttpPut("{id}/devolucao")]
        public async Task<IActionResult> DevolverLivro(int id)
        {
            var devolucao = await _emprestimoRepositorio.BuscarPorId(id);

            await _emprestimoRepositorio.AtualizarStatusEmprestimo(devolucao.Id, StatusEmprestimoEnum.Devolvido);

            return NoContent();
        }
    }
}
