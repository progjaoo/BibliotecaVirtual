using BibliotecaVirtual.Application.Commands.Categorias.Adicionar;
using BibliotecaVirtual.Application.Commands.Categorias.Atualizar;
using BibliotecaVirtual.Application.Commands.Categorias.Deletar;
using BibliotecaVirtual.Application.Queries.Categorias.BuscarPorId;
using BibliotecaVirtual.Application.Queries.Categorias.BuscarTodas;
using BibliotecaVirtual.Core.InterfacesRepositorios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaVirtual.API.Controllers
{
    [Route("api/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CategoriaController(IMediator mediator, ICategoriaRepositorio categoriaRepositorio)
        {
            _mediator = mediator;
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet]
        public async Task <IActionResult> BuscarTodas(string query)
        {
            var busca = new BuscarTodasCategoriasQuery();

            var categorias = await _mediator.Send(busca);

            return Ok(categorias);
        }
        [HttpGet("{id}")]
        public async Task <IActionResult> BuscarPorId(int id)
        {
            var buscarPorIdQuery = new BuscarIdCategoriaQuery(id);

            var categorias = await _mediator.Send(buscarPorIdQuery);

            return Ok(categorias);
        }
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] AddCategoriaCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(BuscarPorId), new { id = id }, command);
        }
        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarCategoriaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task <IActionResult> Deletar(int id)
        {
            var command = new DeletarCategoriaCommand(id);
            
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
