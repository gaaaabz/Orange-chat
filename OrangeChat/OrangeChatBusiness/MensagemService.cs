using OrangeChatModel;
using OrangeChatData;

namespace OrangeChatBusiness;
public class MensagemService : ICrudOrangeChat<MensagemModel>
{
	private readonly ApplicationDbContext _context;

	public MensagemService(ApplicationDbContext context) => _context = context;

	public List<MensagemModel> ListarTodos() => _context.Mensagens.ToList();

	public MensagemModel? ObterPorId(string id) => _context.Mensagens.FirstOrDefault(m => m.Id == id);

	public MensagemModel Criar(MensagemModel mensagem)
	{
		_context.Mensagens.Add(mensagem);
		_context.SaveChanges();
		return mensagem;
	}

	public bool Atualizar(MensagemModel mensagem)
	{
		var existente = _context.Mensagens.Find(mensagem.Id);
		if (existente == null) return false;

		existente.ConversaId = mensagem.ConversaId;
		existente.UsuarioId = mensagem.UsuarioId;
		existente.Texto = mensagem.Texto;

		_context.SaveChanges();
		return true;
	}

	public bool Remover(string id)
	{
		var mensagem = _context.Mensagens.Find(id);
		if (mensagem == null) return false;

		_context.Mensagens.Remove(mensagem);
		_context.SaveChanges();
		return true;
	}
}