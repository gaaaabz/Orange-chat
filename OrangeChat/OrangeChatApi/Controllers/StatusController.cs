```csharp
using Microsoft.AspNetCore.Mvc;
using OrangeChatBusiness;
using OrangeChatModels;

namespace OrangeChatApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController(IStatusService statusService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var status = statusService.ListarTodos();
        return status.Count == 0 ? NoContent() : Ok(status);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var item = statusService.ObterPorId(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public IActionResult Post([FromBody] StatusModel status)
    {
        if (string.IsNullOrWhiteSpace(status.NomeStatus))
            return BadRequest("Nome do status é obrigatório.");

        var criado = statusService.Criar(status);
        return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
    }

    [HttpPut]
    public IActionResult Put([FromBody] StatusModel status)
    {
        if (status == null)
            return BadRequest("Dados inconsistentes.");
        return statusService.Atualizar(status) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        return statusService.Remover(id) ? NoContent() : NotFound();
    }
}
```
