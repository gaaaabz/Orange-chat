using OrangeChatModel;
using OrangeChatData;

namespace OrangeChat.Business.Services;
public class ConversaService : ICrudOrangeChat<ConversaModel>
{
	private readonly ApplicationDbContext _context;

	public ConversaService(ApplicationDbContext context) => _context = context;

	public List<ConversaModel> ListarTodos() => _context.Conversas.ToList();

	public ConversaModel? ObterPorId(string id) => _context.Conversas.FirstOrDefault(c => c.Id == id);

	public ConversaModel Criar(ConversaModel conversa)
	{
		_context.Conversas.Add(conversa);
		_context.SaveChanges();
		return conversa;
	}

	public bool Atualizar(ConversaModel conversa)
	{
		var existente = _context.Conversas.Find(conversa.Id);
		if (existente == null) return false;

		existente.ReclamacaoId = conversa.ReclamacaoId;
		existente.DataFim = conversa.DataFim;
		existente.TipoConversa = conversa.TipoConversa;

		_context.SaveChanges();
		return true;
	}

	public bool Remover(string id)
	{
		var conversa = _context.Conversas.Find(id);
		if (conversa == null) return false;

		_context.Conversas.Remove(conversa);
		_context.SaveChanges();
		return true;
	}
}
