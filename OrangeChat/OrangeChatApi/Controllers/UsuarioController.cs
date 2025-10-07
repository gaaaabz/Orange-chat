```csharp
using Microsoft.AspNetCore.Mvc;
using OrangeChatBusiness;
using OrangeChatModels;

namespace OrangeChatApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController(IUsuarioService usuarioService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var usuarios = usuarioService.ListarTodos();
        return usuarios.Count == 0 ? NoContent() : Ok(usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var usuario = usuarioService.ObterPorId(id);
        return usuario == null ? NotFound() : Ok(usuario);
    }

    [HttpPost]
    public IActionResult Post([FromBody] UsuarioModel usuario)
    {
        if (string.IsNullOrWhiteSpace(usuario.Nome))
            return BadRequest("Nome é obrigatório.");

        var criado = usuarioService.Criar(usuario);
        return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
    }

    [HttpPut]
    public IActionResult Put([FromBody] UsuarioModel usuario)
    {
        if (usuario == null)
            return BadRequest("Dados inconsistentes.");
        return usuarioService.Atualizar(usuario) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        return usuarioService.Remover(id) ? NoContent() : NotFound();
    }
}
```
