```csharp
using Microsoft.AspNetCore.Mvc;
using OrangeChatBusiness;
using OrangeChatModels;

namespace OrangeChatApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FaqsController(IFaqService faqService) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var faqs = faqService.ListarTodos();
        return faqs.Count == 0 ? NoContent() : Ok(faqs);
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        var faq = faqService.ObterPorId(id);
        return faq == null ? NotFound() : Ok(faq);
    }

    [HttpPost]
    public IActionResult Post([FromBody] FaqModel faq)
    {
        if (string.IsNullOrWhiteSpace(faq.Pergunta))
            return BadRequest("Pergunta é obrigatória.");

        var criado = faqService.Criar(faq);
        return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
    }

    [HttpPut]
    public IActionResult Put([FromBody] FaqModel faq)
    {
        if (faq == null)
            return BadRequest("Dados inconsistentes.");
        return faqService.Atualizar(faq) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        return faqService.Remover(id) ? NoContent() : NotFound();
    }
}
```
