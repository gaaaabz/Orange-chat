using Microsoft.AspNetCore.Mvc;
using OrangeRouteBusiness;
using OrangeRouteModel;

namespace OrangeRouteApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrilhaCarreiraController : ControllerBase
{
    private readonly ICrudOrangeRoute<TrilhaCarreiraModel> trilhaService;

    public TrilhaCarreiraController(ICrudOrangeRoute<TrilhaCarreiraModel> trilhaService)
    {
        this.trilhaService = trilhaService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var trilhas = trilhaService.ListarTodos();
        return trilhas.Count == 0 ? NoContent() : Ok(trilhas);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var trilha = trilhaService.ObterPorId(id);
        return trilha == null ? NotFound() : Ok(trilha);
    }

    [HttpPost]
    public IActionResult Post([FromBody] TrilhaCarreiraModel trilha)
    {
        if (string.IsNullOrWhiteSpace(trilha.Conteudo))
            return BadRequest("Conteúdo da trilha é obrigatório.");

        var criado = trilhaService.Criar(trilha);
        return CreatedAtAction(nameof(Get), new { id = criado.IdTrilhaCarreira }, criado);
    }

    [HttpPut]
    public IActionResult Put([FromBody] TrilhaCarreiraModel trilha)
    {
        if (trilha == null)
            return BadRequest("Dados inválidos.");

        return trilhaService.Atualizar(trilha) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return trilhaService.Remover(id) ? NoContent() : NotFound();
    }
}
