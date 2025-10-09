using Microsoft.AspNetCore.Mvc;
using OrangeRouteBusiness;
using OrangeRouteModel;

namespace OrangeRouteApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComentarioController : ControllerBase
{
    private readonly ICrudOrangeRoute<ComentarioModel> comentarioService;

    public ComentarioController(ICrudOrangeRoute<ComentarioModel> comentarioService)
    {
        this.comentarioService = comentarioService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var comentarios = comentarioService.ListarTodos();
        return comentarios.Count == 0 ? NoContent() : Ok(comentarios);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var comentario = comentarioService.ObterPorId(id);
        return comentario == null ? NotFound() : Ok(comentario);
    }

    [HttpPost]
    public IActionResult Post([FromBody] ComentarioModel comentario)
    {
        if (string.IsNullOrWhiteSpace(comentario.Conteudo))
            return BadRequest("Conteúdo do comentário é obrigatório.");

        var criado = comentarioService.Criar(comentario);
        return CreatedAtAction(nameof(Get), new { id = criado.IdComentario }, criado);
    }

    [HttpPut]
    public IActionResult Put([FromBody] ComentarioModel comentario)
    {
        if (comentario == null)
            return BadRequest("Dados inválidos.");

        return comentarioService.Atualizar(comentario) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return comentarioService.Remover(id) ? NoContent() : NotFound();
    }
}
