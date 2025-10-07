namespace OrangeChatModels;
public class AnexoModel
{
    public string? Id { get; set; }
    public required string ReclamacaoId { get; set; }
    public required string NomeArquivo { get; set; }
    public required string TipoArquivo { get; set; }
    public required string Caminho { get; set; }

    public AnexoModel()
    {
        Id = Guid.NewGuid().ToString();
    }
}
