```csharp
using Microsoft.AspNetCore.Mvc;
using OrangeChatBusiness;
using OrangeChatModels;

namespace OrangeChatApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReclamacoesController(IReclamacaoService reclamacaoService) : ControllerBase
{
	[HttpGet]
	public IActionResult Get()
	{
		var reclamacoes = reclamacaoService.ListarTodos();
		return reclamacoes.Count == 0 ? NoContent() : Ok(reclamacoes);
	}

	[HttpGet("{id}")]
	public IActionResult Get(string id)
	{
		var reclamacao = reclamacaoService.ObterPorId(id);
		return reclamacao == null ? NotFound() : Ok(reclamacao);
	}

	[HttpPost]
	public IActionResult Post([FromBody] ReclamacaoModel reclamacao)
	{
		if (string.IsNullOrWhiteSpace(reclamacao.Titulo))
			return BadRequest("Título é obrigatório.");

		var criado = reclamacaoService.Criar(reclamacao);
		return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
	}

	[HttpPut]
	public IActionResult Put([FromBody] ReclamacaoModel reclamacao)
	{
		if (reclamacao == null)
			return BadRequest("Dados inconsistentes.");
		return reclamacaoService.Atualizar(reclamacao) ? NoContent() : NotFound();
	}

	[HttpDelete("{id}")]
	public IActionResult Delete(string id)
	{
		return reclamacaoService.Remover(id) ? NoContent() : NotFound();
	}
}
```
