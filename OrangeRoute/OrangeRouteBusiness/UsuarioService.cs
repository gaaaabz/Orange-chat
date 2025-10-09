using OrangeRouteModel;
using OrangeRouteData;

namespace OrangeRouteBusiness;
public class UsuarioService : ICrudOrangeRoute<UsuarioModel>
{
    private readonly ApplicationDbContext _context;

    public UsuarioService(ApplicationDbContext context) => _context = context;

    public List<UsuarioModel> ListarTodos() => _context.Usuarios.ToList();

    public UsuarioModel? ObterPorId(int id) => _context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);

    public UsuarioModel Criar(UsuarioModel usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return usuario;
    }

    public bool Atualizar(UsuarioModel usuario)
    {
        var existente = _context.Usuarios.Find(usuario.IdUsuario);
        if (existente == null) return false;

        existente.Nome = usuario.Nome;
        existente.Email = usuario.Email;
        existente.Senha = usuario.Senha;
        existente.Telefone = usuario.Telefone;
        existente.IdTipoUsuario = usuario.IdTipoUsuario;
        _context.SaveChanges();
        return true;
    }

    public bool Remover(int id)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario == null) return false;

        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();
        return true;
    }
}
