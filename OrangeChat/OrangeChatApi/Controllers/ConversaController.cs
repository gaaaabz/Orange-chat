```csharp
using Microsoft.AspNetCore.Mvc;
using OrangeChatBusiness;
using OrangeChatModels;

namespace OrangeChatApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConversasController(IConversaService conversaService) : ControllerBase
{
	[HttpGet]
	public IActionResult Get()
	{
		var conversas = conversaService.ListarTodos();
		return conversas.Count == 0 ? NoContent() : Ok(conversas);
	}

	[HttpGet("{id}")]
	public IActionResult Get(string id)
	{
		var conversa = conversaService.ObterPorId(id);
		return conversa == null ? NotFound() : Ok(conversa);
	}

	[HttpPost]
	public IActionResult Post([FromBody] ConversaModel conversa)
	{
		if (string.IsNullOrWhiteSpace(conversa.TipoConversa))
			return BadRequest("Tipo de conversa é obrigatório.");

		var criado = conversaService.Criar(conversa);
		return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
	}

	[HttpPut]
	public IActionResult Put([FromBody] ConversaModel conversa)
	{
		if (conversa == null)
			return BadRequest("Dados inconsistentes.");
		return conversaService.Atualizar(conversa) ? NoContent() : NotFound();
	}

	[HttpDelete("{id}")]
	public IActionResult Delete(string id)
	{
		return conversaService.Remover(id) ? NoContent() : NotFound();
	}
}
```
