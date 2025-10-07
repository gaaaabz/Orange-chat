using OrangeChatModel;
using OrangeChatData;

namespace OrangeChatBusiness;
public class CategoriaService : ICrudOrangeChat<CategoriaModel>
{
    private readonly ApplicationDbContext _context;

    public CategoriaService(ApplicationDbContext context) => _context = context;

    public List<CategoriaModel> ListarTodos() => _context.Categorias.ToList();

    public CategoriaModel? ObterPorId(string id) => _context.Categorias.FirstOrDefault(c => c.Id == id);

    public CategoriaModel Criar(CategoriaModel categoria)
    {
        _context.Categorias.Add(categoria);
        _context.SaveChanges();
        return categoria;
    }

    public bool Atualizar(CategoriaModel categoria)
    {
        var existente = _context.Categorias.Find(categoria.Id);
        if (existente == null) return false;

        existente.NomeCategoria = categoria.NomeCategoria;
        existente.Descricao = categoria.Descricao;

        _context.SaveChanges();
        return true;
    }

    public bool Remover(string id)
    {
        var categoria = _context.Categorias.Find(id);
        if (categoria == null) return false;

        _context.Categorias.Remove(categoria);
        _context.SaveChanges();
        return true;
    }
}
