using Microsoft.AspNetCore.Mvc;
using OrangeRouteBusiness;
using OrangeRouteModel;

namespace OrangeRouteApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagController : ControllerBase
{
    private readonly ICrudOrangeRoute<TagModel> tagService;

    public TagController(ICrudOrangeRoute<TagModel> tagService)
    {
        this.tagService = tagService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var tags = tagService.ListarTodos();
        return tags.Count == 0 ? NoContent() : Ok(tags);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var tag = tagService.ObterPorId(id);
        return tag == null ? NotFound() : Ok(tag);
    }

    [HttpPost]
    public IActionResult Post([FromBody] TagModel tag)
    {
        if (string.IsNullOrWhiteSpace(tag.Nome))
            return BadRequest("Nome da tag é obrigatório.");

        var criado = tagService.Criar(tag);
        return CreatedAtAction(nameof(Get), new { id = criado.IdTag }, criado);
    }

    [HttpPut]
    public IActionResult Put([FromBody] TagModel tag)
    {
        if (tag == null)
            return BadRequest("Dados inválidos.");

        return tagService.Atualizar(tag) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return tagService.Remover(id) ? NoContent() : NotFound();
    }
}
