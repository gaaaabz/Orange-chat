namespace OrangeChatModels;
public class StatusModel
{
    public string? Id { get; set; }
    public required string NomeStatus { get; set; }
    public string? Descricao { get; set; }

    public StatusModel()
    {
        Id = Guid.NewGuid().ToString();
    }
}
