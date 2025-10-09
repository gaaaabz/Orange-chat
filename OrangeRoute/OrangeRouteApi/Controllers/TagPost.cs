using Microsoft.AspNetCore.Mvc;
using OrangeRouteBusiness;
using OrangeRouteModel;

namespace OrangeRouteApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagPostController : ControllerBase
{
    private readonly ICrudOrangeRoute<TagPostModel> tagPostService;

    public TagPostController(ICrudOrangeRoute<TagPostModel> tagPostService)
    {
        this.tagPostService = tagPostService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var tagPosts = tagPostService.ListarTodos();
        return tagPosts.Count == 0 ? NoContent() : Ok(tagPosts);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var tagPost = tagPostService.ObterPorId(id);
        return tagPost == null ? NotFound() : Ok(tagPost);
    }

    [HttpPost]
    public IActionResult Post([FromBody] TagPostModel tagPost)
    {
        if (tagPost.IdTag <= 0 || tagPost.IdTrilhaCarreira <= 0)
            return BadRequest("IDs de Tag e TrilhaCarreira são obrigatórios.");

        var criado = tagPostService.Criar(tagPost);
        return CreatedAtAction(nameof(Get), new { id = criado.IdTagPost }, criado);
    }

    [HttpPut]
    public IActionResult Put([FromBody] TagPostModel tagPost)
    {
        if (tagPost == null)
            return BadRequest("Dados inválidos.");

        return tagPostService.Atualizar(tagPost) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return tagPostService.Remover(id) ? NoContent() : NotFound();
    }
}
