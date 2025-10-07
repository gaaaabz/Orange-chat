```csharp
using Microsoft.AspNetCore.Mvc;
using OrangeChatBusiness;
using OrangeChatModels;

namespace OrangeChatApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MensagensController(IMensagemService mensagemService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var mensagens = mensagemService.ListarTodos();
        return mensagens.Count == 0 ? NoContent() : Ok(mensagens);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var mensagem = mensagemService.ObterPorId(id);
        return mensagem == null ? NotFound() : Ok(mensagem);
    }

    [HttpPost]
    public IActionResult Post([FromBody] MensagemModel mensagem)
    {
        if (string.IsNullOrWhiteSpace(mensagem.Texto))
            return BadRequest("Texto da mensagem é obrigatório.");

        var criado = mensagemService.Criar(mensagem);
        return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
    }

    [HttpPut]
    public IActionResult Put([FromBody] MensagemModel mensagem)
    {
        if (mensagem == null)
            return BadRequest("Dados inconsistentes.");
        return mensagemService.Atualizar(mensagem) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        return mensagemService.Remover(id) ? NoContent() : NotFound();
    }
}
```
