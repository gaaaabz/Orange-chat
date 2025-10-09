using Microsoft.AspNetCore.Mvc;
using OrangeRouteBusiness;
using OrangeRouteModel;

namespace OrangeRouteApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoritosController : ControllerBase
{
    private readonly ICrudOrangeRoute<FavoritosModel> favoritosService;

    public FavoritosController(ICrudOrangeRoute<FavoritosModel> favoritosService)
    {
        this.favoritosService = favoritosService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var lista = favoritosService.ListarTodos();
        return lista.Count == 0 ? NoContent() : Ok(lista);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var favorito = favoritosService.ObterPorId(id);
        return favorito == null ? NotFound() : Ok(favorito);
    }

    [HttpPost]
    public IActionResult Post([FromBody] FavoritosModel favorito)
    {
        if (favorito.IdUsuario <= 0)
            return BadRequest("Usuário inválido.");

        var criado = favoritosService.Criar(favorito);
        return CreatedAtAction(nameof(Get), new { id = criado.IdFavoritos }, criado);
    }

    [HttpPut]
    public IActionResult Put([FromBody] FavoritosModel favorito)
    {
        if (favorito == null)
            return BadRequest("Dados inválidos.");

        return favoritosService.Atualizar(favorito) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return favoritosService.Remover(id) ? NoContent() : NotFound();
    }
}
