using OrangeRouteModel;
using OrangeRouteData;

namespace OrangeRouteBusiness;
public class ComentarioService : ICrudOrangeRoute<ComentarioModel>
{
    private readonly ApplicationDbContext _context;

    public ComentarioService(ApplicationDbContext context) => _context = context;

    public List<ComentarioModel> ListarTodos() => _context.Comentarios.ToList();

    public ComentarioModel? ObterPorId(int id) => _context.Comentarios.FirstOrDefault(c => c.IdComentario == id);

    public ComentarioModel Criar(ComentarioModel comentario)
    {
        _context.Comentarios.Add(comentario);
        _context.SaveChanges();
        return comentario;
    }

    public bool Atualizar(ComentarioModel comentario)
    {
        var existente = _context.Comentarios.Find(comentario.IdComentario);
        if (existente == null) return false;

        existente.Conteudo = comentario.Conteudo;
        existente.IdTrilhaCarreira = comentario.IdTrilhaCarreira;
        existente.IdUsuario = comentario.IdUsuario;
        _context.SaveChanges();
        return true;
    }

    public bool Remover(int id)
    {
        var comentario = _context.Comentarios.Find(id);
        if (comentario == null) return false;

        _context.Comentarios.Remove(comentario);
        _context.SaveChanges();
        return true;
    }
}
