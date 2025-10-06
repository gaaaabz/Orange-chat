using CandidatosModel;
using CandidatosData;

namespace CandidatosBusiness;
public class CandidatoService(ApplicationDbContext context) : ICandidatoService
{
    private readonly ApplicationDbContext _context = context;

    public List<CandidatoModel> ListarTodos() => [.. _context.Candidatos];

    public CandidatoModel? ObterPorId(string id) =>
        _context.Candidatos.FirstOrDefault(c => c.Id == id);

    public CandidatoModel Criar(CandidatoModel candidato)
    {
        _context.Candidatos.Add(candidato);
        _context.SaveChanges();
        return candidato;
    }

    public bool Atualizar(CandidatoModel candidato)
    {
        var existente = _context.Candidatos.Find(candidato.Id);
        if (existente == null) return false;

        existente.Nome = candidato.Nome;
        existente.Partido = candidato.Partido;
        existente.Idade = candidato.Idade;

        _context.SaveChanges();
        return true;
    }

    public bool Remover(string id)
    {
        var candidato = _context.Candidatos.Find(id);
        if (candidato == null) return false;

        _context.Candidatos.Remove(candidato);
        _context.SaveChanges();
        return true;
    }
}
