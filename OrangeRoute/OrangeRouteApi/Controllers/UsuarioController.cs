using Microsoft.AspNetCore.Mvc;
using OrangeRouteBusiness;
using OrangeRouteModel;

namespace OrangeRouteApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ICrudOrangeRoute<UsuarioModel> usuarioService;

    public UsuarioController(ICrudOrangeRoute<UsuarioModel> usuarioService)
    {
        this.usuarioService = usuarioService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var usuarios = usuarioService.ListarTodos();
        return usuarios.Count == 0 ? NoContent() : Ok(usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var usuario = usuarioService.ObterPorId(id);
        return usuario == null ? NotFound() : Ok(usuario);
    }

    [HttpPost]
    public IActionResult Post([FromBody] UsuarioModel usuario)
    {
        if (string.IsNullOrWhiteSpace(usuario.Nome) || string.IsNullOrWhiteSpace(usuario.Email))
            return BadRequest("Nome e e-mail são obrigatórios.");

        var criado = usuarioService.Criar(usuario);
        return CreatedAtAction(nameof(Get), new { id = criado.IdUsuario }, criado);
    }

    [HttpPut]
    public IActionResult Put([FromBody] UsuarioModel usuario)
    {
        if (usuario == null)
            return BadRequest("Dados inválidos.");

        return usuarioService.Atualizar(usuario) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return usuarioService.Remover(id) ? NoContent() : NotFound();
    }
}
