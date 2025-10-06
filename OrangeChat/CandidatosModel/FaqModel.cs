namespace OrangeChat.Domain.Models;
public class FaqModel
{
    public string? Id { get; set; }
    public required string Pergunta { get; set; }
    public required string Resposta { get; set; }
    public required string CategoriaId { get; set; }

    public FaqModel()
    {
        Id = Guid.NewGuid().ToString();
    }
}
