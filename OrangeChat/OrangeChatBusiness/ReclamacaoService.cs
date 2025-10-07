using OrangeChatModel;
using OrangeChatData;

namespace OrangeChatBusiness;
public class ReclamacaoService : ICrudOrangeChat<ReclamacaoModel>
{
	private readonly ApplicationDbContext _context;

	public ReclamacaoService(ApplicationDbContext context) => _context = context;

	public List<ReclamacaoModel> ListarTodos() => _context.Reclamacoes.ToList();

	public ReclamacaoModel? ObterPorId(string id) => _context.Reclamacoes.FirstOrDefault(r => r.Id == id);

	public ReclamacaoModel Criar(ReclamacaoModel reclamacao)
	{
		_context.Reclamacoes.Add(reclamacao);
		_context.SaveChanges();
		return reclamacao;
	}

	public bool Atualizar(ReclamacaoModel reclamacao)
	{
		var existente = _context.Reclamacoes.Find(reclamacao.Id);
		if (existente == null) return false;

		existente.UsuarioId = reclamacao.UsuarioId;
		existente.CategoriaId = reclamacao.CategoriaId;
		existente.StatusId = reclamacao.StatusId;
		existente.Titulo = reclamacao.Titulo;
		existente.Descricao = reclamacao.Descricao;
		existente.DataFechamento = reclamacao.DataFechamento;

		_context.SaveChanges();
		return true;
	}

	public bool Remover(string id)
	{
		var reclamacao = _context.Reclamacoes.Find(id);
		if (reclamacao == null) return false;

		_context.Reclamacoes.Remove(reclamacao);
		_context.SaveChanges();
		return true;
	}
}
