using OrangeRouteModel;
using OrangeRouteData;

namespace OrangeRouteBusiness;
public class FavoritosService : ICrudOrangeRoute<FavoritosModel>
{
    private readonly ApplicationDbContext _context;

    public FavoritosService(ApplicationDbContext context) => _context = context;

    public List<FavoritosModel> ListarTodos() => _context.Favoritos.ToList();

    public FavoritosModel? ObterPorId(int id) => _context.Favoritos.FirstOrDefault(f => f.IdFavoritos == id);

    public FavoritosModel Criar(FavoritosModel favorito)
    {
        _context.Favoritos.Add(favorito);
        _context.SaveChanges();
        return favorito;
    }

    public bool Atualizar(FavoritosModel favorito)
    {
        var existente = _context.Favoritos.Find(favorito.IdFavoritos);
        if (existente == null) return false;

        existente.IdUsuario = favorito.IdUsuario;
        _context.SaveChanges();
        return true;
    }

    public bool Remover(int id)
    {
        var favorito = _context.Favoritos.Find(id);
        if (favorito == null) return false;

        _context.Favoritos.Remove(favorito);
        _context.SaveChanges();
        return true;
    }
}
