using OrangeChatModel;
using OrangeChatData;

namespace OrangeChatBusiness;
public class AvaliacaoService : ICrudOrangeChat<AvaliacaoModel>
{
    private readonly ApplicationDbContext _context;

    public AvaliacaoService(ApplicationDbContext context) => _context = context;

    public List<AvaliacaoModel> ListarTodos() => _context.Avaliacoes.ToList();

    public AvaliacaoModel? ObterPorId(string id) => _context.Avaliacoes.FirstOrDefault(a => a.Id == id);

    public AvaliacaoModel Criar(AvaliacaoModel avaliacao)
    {
        _context.Avaliacoes.Add(avaliacao);
        _context.SaveChanges();
        return avaliacao;
    }

    public bool Atualizar(AvaliacaoModel avaliacao)
    {
        var existente = _context.Avaliacoes.Find(avaliacao.Id);
        if (existente == null) return false;

        existente.ReclamacaoId = avaliacao.ReclamacaoId;
        existente.Nota = avaliacao.Nota;
        existente.Comentario = avaliacao.Comentario;

        _context.SaveChanges();
        return true;
    }

    public bool Remover(string id)
    {
        var avaliacao = _context.Avaliacoes.Find(id);
        if (avaliacao == null) return false;

        _context.Avaliacoes.Remove(avaliacao);
        _context.SaveChanges();
        return true;
    }
}

