using OrangeChatModel;
using OrangeChatData;

namespace OrangeChatBusiness;
public class StatusService : ICrudOrangeChat<StatusModel>
{
	private readonly ApplicationDbContext _context;

	public StatusService(ApplicationDbContext context) => _context = context;

	public List<StatusModel> ListarTodos() => _context.Status.ToList();

	public StatusModel? ObterPorId(string id) => _context.Status.FirstOrDefault(s => s.Id == id);

	public StatusModel Criar(StatusModel status)
	{
		_context.Status.Add(status);
		_context.SaveChanges();
		return status;
	}

	public bool Atualizar(StatusModel status)
	{
		var existente = _context.Status.Find(status.Id);
		if (existente == null) return false;

		existente.NomeStatus = status.NomeStatus;
		existente.Descricao = status.Descricao;

		_context.SaveChanges();
		return true;
	}

	public bool Remover(string id)
	{
		var status = _context.Status.Find(id);
		if (status == null) return false;

		_context.Status.Remove(status);
		_context.SaveChanges();
		return true;
	}
}
