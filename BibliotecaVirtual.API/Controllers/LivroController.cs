using BibliotecaVirtual.Application.Commands.Livro.AdicionarLivro;
using BibliotecaVirtual.Application.Commands.Livros.Atualizar;
using BibliotecaVirtual.Application.Commands.Livros.Deletar;
using BibliotecaVirtual.Application.Queries.Livro.BuscarPorId;
using BibliotecaVirtual.Application.Queries.Livro.BuscarTodos;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaVirtual.API.Controllers
{
    [Route("api/livros")]
    public class LivroController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILivroRepositorio _livroRepositorio;
        public LivroController(IMediator mediator, ILivroRepositorio livroRepositorio)
        {
            _mediator = mediator;
            _livroRepositorio = livroRepositorio;
        }

        [HttpGet("buscarTodos")]
        public async Task <IActionResult> BuscarTodos()
        {
            var buscarTodos = new BuscarTodosQuery();

            var livros = await _mediator.Send(buscarTodos);

            return Ok(livros);
        }
        [HttpGet("buscarPorId/{id}")]
        public async Task <IActionResult> BuscarPorId(int id)
        {
            var query = new LivroPorIdQuery(id);
            var livro = await _mediator.Send(query);

            return Ok(livro);
        }
        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] AddLivroCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(BuscarPorId), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarLivroCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("deletar/{id}")]
        public async Task <IActionResult> Deletar(int id)
        {
            var command = new DeletarLivroCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
        [HttpPost("finalizar/{id}")]
        public async Task <IActionResult> FinalizarLeitura(int id)
        {
            await _livroRepositorio.FinalizarLeitura(id);
            await _livroRepositorio.SaveChangesAsync();

            return Ok();
        }
    }
}
