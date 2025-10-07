using OrangeChatModel;
using OrangeChatData;

namespace OrangeChatBusiness;
public class FaqService : ICrudOrangeChat<FaqModel>
{
	private readonly ApplicationDbContext _context;

	public FaqService(ApplicationDbContext context) => _context = context;

	public List<FaqModel> ListarTodos() => _context.Faqs.ToList();

	public FaqModel? ObterPorId(string id) => _context.Faqs.FirstOrDefault(f => f.Id == id);

	public FaqModel Criar(FaqModel faq)
	{
		_context.Faqs.Add(faq);
		_context.SaveChanges();
		return faq;
	}

	public bool Atualizar(FaqModel faq)
	{
		var existente = _context.Faqs.Find(faq.Id);
		if (existente == null) return false;

		existente.Pergunta = faq.Pergunta;
		existente.Resposta = faq.Resposta;
		existente.CategoriaId = faq.CategoriaId;

		_context.SaveChanges();
		return true;
	}

	public bool Remover(string id)
	{
		var faq = _context.Faqs.Find(id);
		if (faq == null) return false;

		_context.Faqs.Remove(faq);
		_context.SaveChanges();
		return true;
	}
}