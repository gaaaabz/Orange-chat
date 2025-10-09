using OrangeRouteModel;
using OrangeRouteData;

namespace OrangeRouteBusiness;
public class TipoUsuarioService : ICrudOrangeRoute<TipoUsuarioModel>
{
    private readonly ApplicationDbContext _context;

    public TipoUsuarioService(ApplicationDbContext context) => _context = context;

    public List<TipoUsuarioModel> ListarTodos() => _context.TiposUsuario.ToList();

    public TipoUsuarioModel? ObterPorId(int id) => _context.TiposUsuario.FirstOrDefault(t => t.IdTipoUsuario == id);

    public TipoUsuarioModel Criar(TipoUsuarioModel tipoUsuario)
    {
        _context.TiposUsuario.Add(tipoUsuario);
        _context.SaveChanges();
        return tipoUsuario;
    }

    public bool Atualizar(TipoUsuarioModel tipoUsuario)
    {
        var existente = _context.TiposUsuario.Find(tipoUsuario.IdTipoUsuario);
        if (existente == null) return false;

        existente.Nome = tipoUsuario.Nome;
        _context.SaveChanges();
        return true;
    }

    public bool Remover(int id)
    {
        var tipo = _context.TiposUsuario.Find(id);
        if (tipo == null) return false;

        _context.TiposUsuario.Remove(tipo);
        _context.SaveChanges();
        return true;
    }
}
