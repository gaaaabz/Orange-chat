using OrangeRouteModel;
using OrangeRouteData;

namespace OrangeRouteBusiness;
public class TrilhaCarreiraService : ICrudOrangeRoute<TrilhaCarreiraModel>
{
    private readonly ApplicationDbContext _context;

    public TrilhaCarreiraService(ApplicationDbContext context) => _context = context;

    public List<TrilhaCarreiraModel> ListarTodos() => _context.TrilhasCarreira.ToList();

    public TrilhaCarreiraModel? ObterPorId(int id) => _context.TrilhasCarreira.FirstOrDefault(t => t.IdTrilhaCarreira == id);

    public TrilhaCarreiraModel Criar(TrilhaCarreiraModel trilha)
    {
        _context.TrilhasCarreira.Add(trilha);
        _context.SaveChanges();
        return trilha;
    }

    public bool Atualizar(TrilhaCarreiraModel trilha)
    {
        var existente = _context.TrilhasCarreira.Find(trilha.IdTrilhaCarreira);
        if (existente == null) return false;

        existente.Conteudo = trilha.Conteudo;
        existente.IdFavoritos = trilha.IdFavoritos;
        _context.SaveChanges();
        return true;
    }

    public bool Remover(int id)
    {
        var trilha = _context.TrilhasCarreira.Find(id);
        if (trilha == null) return false;

        _context.TrilhasCarreira.Remove(trilha);
        _context.SaveChanges();
        return true;
    }
}
