namespace OrangeChat.Domain.Models;
public class AvaliacaoModel
{
    public string? Id { get; set; }
    public required string ReclamacaoId { get; set; }
    public required int Nota { get; set; } // entre 1 e 5
    public string? Comentario { get; set; }
    public DateTime DataAvaliacao { get; set; }

    public AvaliacaoModel()
    {
        Id = Guid.NewGuid().ToString();
        DataAvaliacao = DateTime.Now;
    }
}
