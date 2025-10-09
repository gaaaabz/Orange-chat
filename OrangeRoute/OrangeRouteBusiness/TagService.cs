using OrangeRouteModel;
using OrangeRouteData;

namespace OrangeRouteBusiness;
public class TagService : ICrudOrangeRoute<TagModel>
{
    private readonly ApplicationDbContext _context;

    public TagService(ApplicationDbContext context) => _context = context;

    public List<TagModel> ListarTodos() => _context.Tags.ToList();

    public TagModel? ObterPorId(int id) => _context.Tags.FirstOrDefault(t => t.IdTag == id);

    public TagModel Criar(TagModel tag)
    {
        _context.Tags.Add(tag);
        _context.SaveChanges();
        return tag;
    }

    public bool Atualizar(TagModel tag)
    {
        var existente = _context.Tags.Find(tag.IdTag);
        if (existente == null) return false;

        existente.Nome = tag.Nome;
        _context.SaveChanges();
        return true;
    }

    public bool Remover(int id)
    {
        var tag = _context.Tags.Find(id);
        if (tag == null) return false;

        _context.Tags.Remove(tag);
        _context.SaveChanges();
        return true;
    }
}
