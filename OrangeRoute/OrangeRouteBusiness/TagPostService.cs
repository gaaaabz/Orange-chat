using OrangeRouteModel;
using OrangeRouteData;

namespace OrangeRouteBusiness;
public class TagPostService : ICrudOrangeRoute<TagPostModel>
{
    private readonly ApplicationDbContext _context;

    public TagPostService(ApplicationDbContext context) => _context = context;

    public List<TagPostModel> ListarTodos() => _context.TagsPost.ToList();

    public TagPostModel? ObterPorId(int id) => _context.TagsPost.FirstOrDefault(tp => tp.IdTagPost == id);

    public TagPostModel Criar(TagPostModel tagPost)
    {
        _context.TagsPost.Add(tagPost);
        _context.SaveChanges();
        return tagPost;
    }

    public bool Atualizar(TagPostModel tagPost)
    {
        var existente = _context.TagsPost.Find(tagPost.IdTagPost);
        if (existente == null) return false;

        existente.IdTag = tagPost.IdTag;
        existente.IdTrilhaCarreira = tagPost.IdTrilhaCarreira;
        _context.SaveChanges();
        return true;
    }

    public bool Remover(int id)
    {
        var tagPost = _context.TagsPost.Find(id);
        if (tagPost == null) return false;

        _context.TagsPost.Remove(tagPost);
        _context.SaveChanges();
        return true;
    }
}
