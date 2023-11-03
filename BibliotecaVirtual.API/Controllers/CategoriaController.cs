using System.ComponentModel;
using BibliotecaVirtual.Application.Queries.Categorias.BuscarPorId;
using BibliotecaVirtual.Application.Queries.Categorias.BuscarTodas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaVirtual.API.Controllers
{
    [Route("api/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("buscarTodas")]
        public async Task <IActionResult> BuscarTodas(string query)
        {
            var busca = new BuscarTodasCategoriasQuery();

            var categorias = await _mediator.Send(busca);

            return Ok(categorias);
        }
        [HttpGet("buscarPorId/{id}")]
        public async Task <IActionResult> BuscarPorId(int id)
        {
            var buscarPorIdQuery = new BuscarIdCategoriaQuery(id);

            var categorias = await _mediator.Send(buscarPorIdQuery);

            return Ok(categorias);
        }
    }
}
