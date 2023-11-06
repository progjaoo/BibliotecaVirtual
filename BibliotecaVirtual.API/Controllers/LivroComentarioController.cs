using BibliotecaVirtual.Application.Commands.LivroComentario.AddComentario;
using BibliotecaVirtual.Application.Commands.LivroComentario.AtualizarComentario;
using BibliotecaVirtual.Application.Commands.LivroComentario.DeletarComentario;
using BibliotecaVirtual.Application.Queries.LivroComentario.BuscarPorId;
using BibliotecaVirtual.Application.Queries.LivroComentario.BuscarTodos;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaVirtual.API.Controllers
{
    [Route("api/comentarios")]
    public class LivroComentarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LivroComentarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodas(int idLivro)
        {
            var busca = new BuscarTodosComentariosQuery(idLivro);

            var comentarios = await _mediator.Send(busca);

            return Ok(comentarios);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var busca = new BuscarComentarioPorIdQuery(id);

            var comentario = await _mediator.Send(busca);

            return Ok(comentario);
        }
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] AdicionarComentarioCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(BuscarPorId), new { id = id }, command);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarComentarioCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var deletar = new DeletarComentarioCommand(id);
            await _mediator.Send(deletar);

            return NoContent();
        }
    }
}
