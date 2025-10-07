```csharp
using Microsoft.AspNetCore.Mvc;
using OrangeChatBusiness;
using OrangeChatModels;

namespace OrangeChatApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnexosController(IAnexoService anexoService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var anexos = anexoService.ListarTodos();
        return anexos.Count == 0 ? NoContent() : Ok(anexos);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var anexo = anexoService.ObterPorId(id);
        return anexo == null ? NotFound() : Ok(anexo);
    }

    [HttpPost]
    public IActionResult Post([FromBody] AnexoModel anexo)
    {
        if (string.IsNullOrWhiteSpace(anexo.NomeArquivo))
            return BadRequest("Nome do arquivo é obrigatório.");

        var criado = anexoService.Criar(anexo);
        return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
    }

    [HttpPut]
    public IActionResult Put([FromBody] AnexoModel anexo)
    {
        if (anexo == null)
            return BadRequest("Dados inconsistentes.");
        return anexoService.Atualizar(anexo) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        return anexoService.Remover(id) ? NoContent() : NotFound();
    }
}
```
