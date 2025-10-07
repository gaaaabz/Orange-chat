namespace OrangeChatModels;
public class CategoriaModel
{
    public string? Id { get; set; }
    public required string NomeCategoria { get; set; }
    public string? Descricao { get; set; }

    public CategoriaModel()
    {
        Id = Guid.NewGuid().ToString();
    }
}
