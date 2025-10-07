```csharp
using Microsoft.AspNetCore.Mvc;
using OrangeChatBusiness;
using OrangeChatModels;

namespace OrangeChatApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController(ICategoriaService categoriaService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var categorias = categoriaService.ListarTodos();
        return categorias.Count == 0 ? NoContent() : Ok(categorias);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var categoria = categoriaService.ObterPorId(id);
        return categoria == null ? NotFound() : Ok(categoria);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CategoriaModel categoria)
    {
        if (string.IsNullOrWhiteSpace(categoria.NomeCategoria))
            return BadRequest("Nome da categoria é obrigatório.");

        var criado = categoriaService.Criar(categoria);
        return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
    }

    [HttpPut]
    public IActionResult Put([FromBody] CategoriaModel categoria)
    {
        if (categoria == null)
            return BadRequest("Dados inconsistentes.");
        return categoriaService.Atualizar(categoria) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        return categoriaService.Remover(id) ? NoContent() : NotFound();
    }
}
```
