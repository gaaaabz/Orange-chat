namespace OrangeChatModels;
public class MensagemModel
{
    public string? Id { get; set; }
    public required string ConversaId { get; set; }
    public required string UsuarioId { get; set; }
    public required string Texto { get; set; }
    public DateTime DataEnvio { get; set; }

    public MensagemModel()
    {
        Id = Guid.NewGuid().ToString();
        DataEnvio = DateTime.Now;
    }
}
