using BibliotecaVirtual.Application.Commands.AdicionarLivro;
using BibliotecaVirtual.Application.Queries.LivroPorIdQuery;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaVirtual.API.Controllers
{
    [Route("api/livros")]
    public class LivroController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LivroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult BuscarTodos(string query)
        {
            //var livro = _livroService.BuscarTodos(query);

            //if(livro == null)
            //{
            //    return BadRequest();
            //}

            return Ok();
        }
        [HttpGet("{id}")]
        public async Task <IActionResult> BuscarPorId(int id)
        {
            var query = new LivroPorIdQuery(id);
            var livro = await _mediator.Send(query);

            return Ok(livro);
        }
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] AddLivroCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(BuscarPorId), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(/*int id, [FromBody] AtualizarLivroModel atualizarLivro*/)
        {
            //if (atualizarLivro.Descricao.Length > 1000 == null)
            //{
            //    return BadRequest();
            //}
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok();
        }
        [HttpPost("finalizar/{id}")]
        public IActionResult FinalizarLeitura(int id)
        {
            return Ok();
        }
    }
}
