using Microsoft.AspNetCore.Mvc;
using OrangeRouteBusiness;
using OrangeRouteModel;

namespace OrangeRouteApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TipoUsuarioController : ControllerBase
{
    private readonly ICrudOrangeRoute<TipoUsuarioModel> tipoUsuarioService;

    public TipoUsuarioController(ICrudOrangeRoute<TipoUsuarioModel> tipoUsuarioService)
    {
        this.tipoUsuarioService = tipoUsuarioService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var tipos = tipoUsuarioService.ListarTodos();
        return tipos.Count == 0 ? NoContent() : Ok(tipos);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var tipo = tipoUsuarioService.ObterPorId(id);
        return tipo == null ? NotFound() : Ok(tipo);
    }

    [HttpPost]
    public IActionResult Post([FromBody] TipoUsuarioModel tipo)
    {
        if (string.IsNullOrWhiteSpace(tipo.Nome))
            return BadRequest("O nome do tipo de usuário é obrigatório.");

        var criado = tipoUsuarioService.Criar(tipo);
        return CreatedAtAction(nameof(Get), new { id = criado.IdTipoUsuario }, criado);
    }

    [HttpPut]
    public IActionResult Put([FromBody] TipoUsuarioModel tipo)
    {
        if (tipo == null)
            return BadRequest("Dados inválidos.");

        return tipoUsuarioService.Atualizar(tipo) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return tipoUsuarioService.Remover(id) ? NoContent() : NotFound();
    }
}
