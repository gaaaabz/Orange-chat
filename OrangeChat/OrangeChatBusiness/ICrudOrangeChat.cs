using CandidatosModel;

namespace CandidatosBusiness
{
    public interface ICandidatoService
    {
        List<CandidatoModel> ListarTodos();
        CandidatoModel? ObterPorId(string id);
        CandidatoModel Criar(CandidatoModel candidato);
        bool Atualizar(CandidatoModel candidato);
        bool Remover(string id);
    }
}