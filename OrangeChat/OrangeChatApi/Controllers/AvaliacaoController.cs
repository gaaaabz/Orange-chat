```csharp
using Microsoft.AspNetCore.Mvc;
using OrangeChatBusiness;
using OrangeChatModels;

namespace OrangeChatApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AvaliacoesController(IAvaliacaoService avaliacaoService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var avaliacoes = avaliacaoService.ListarTodos();
        return avaliacoes.Count == 0 ? NoContent() : Ok(avaliacoes);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var avaliacao = avaliacaoService.ObterPorId(id);
        return avaliacao == null ? NotFound() : Ok(avaliacao);
    }

    [HttpPost]
    public IActionResult Post([FromBody] AvaliacaoModel avaliacao)
    {
        if (avaliacao.Nota < 1 || avaliacao.Nota > 5)
            return BadRequest("A nota deve estar entre 1 e 5.");

        var criado = avaliacaoService.Criar(avaliacao);
        return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
    }

    [HttpPut]
    public IActionResult Put([FromBody] AvaliacaoModel avaliacao)
    {
        if (avaliacao == null)
            return BadRequest("Dados inconsistentes.");
        return avaliacaoService.Atualizar(avaliacao) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        return avaliacaoService.Remover(id) ? NoContent() : NotFound();
    }
}
```
