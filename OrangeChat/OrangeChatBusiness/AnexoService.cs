using OrangeChatModel;
using OrangeChatData;

namespace OrangeChatBusiness;
public class AnexoService : ICrudOrangeChat<AnexoModel>
{
    private readonly ApplicationDbContext _context;

    public AnexoService(ApplicationDbContext context) => _context = context;

    public List<AnexoModel> ListarTodos() => _context.Anexos.ToList();

    public AnexoModel? ObterPorId(string id) => _context.Anexos.FirstOrDefault(a => a.Id == id);

    public AnexoModel Criar(AnexoModel anexo)
    {
        _context.Anexos.Add(anexo);
        _context.SaveChanges();
        return anexo;
    }

    public bool Atualizar(AnexoModel anexo)
    {
        var existente = _context.Anexos.Find(anexo.Id);
        if (existente == null) return false;

        existente.ReclamacaoId = anexo.ReclamacaoId;
        existente.NomeArquivo = anexo.NomeArquivo;
        existente.TipoArquivo = anexo.TipoArquivo;
        existente.Caminho = anexo.Caminho;

        _context.SaveChanges();
        return true;
    }

    public bool Remover(string id)
    {
        var anexo = _context.Anexos.Find(id);
        if (anexo == null) return false;

        _context.Anexos.Remove(anexo);
        _context.SaveChanges();
        return true;
    }
}
