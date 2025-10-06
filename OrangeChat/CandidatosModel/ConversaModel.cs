namespace OrangeChat.Domain.Models;
public class ConversaModel
{
    public string? Id { get; set; }
    public required string ReclamacaoId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public required string TipoConversa { get; set; }

    public ConversaModel()
    {
        Id = Guid.NewGuid().ToString();
        DataInicio = DateTime.Now;
    }
}