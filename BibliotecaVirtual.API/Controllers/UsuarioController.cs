using System.Net.Http.Headers;
using BibliotecaVirtual.Application.Commands.Usuarios.AddUsuario;
using BibliotecaVirtual.Application.Commands.Usuarios.AtualizarUsuario;
using BibliotecaVirtual.Application.Commands.Usuarios.DeletarUsuario;
using BibliotecaVirtual.Application.Commands.Usuarios.LoginUsuario;
using BibliotecaVirtual.Application.Queries.Usuarios.BuscarPorId;
using BibliotecaVirtual.Application.Queries.Usuarios.BuscarTodos;
using BibliotecaVirtual.Core.Entidades;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaVirtual.API.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodos()
        {
            var query = new BuscarTodosUsuariosQuery();

            var usuarios = await _mediator.Send(query);

            if (usuarios == null)
            {
                return BadRequest();
            }

            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id )
        {
            var query = new BuscarUsuarioPorIdQuery(id);

            var usuario = await _mediator.Send(query);

            if(usuario == null)
            {
                return BadRequest();
            }

            return Ok(usuario);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task <IActionResult> Criar([FromBody] CriarUsuarioCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(BuscarPorId), new { id = id }, command);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] AtualizarUsuarioCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            if(loginUserViewModel == null)
            {
                return BadRequest();
            }

            return Ok(loginUserViewModel);
        }
        [HttpDelete("{id}")]
        public async Task <IActionResult> Deletar(int id)
        {
            var command = new DeletarUsuarioCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
