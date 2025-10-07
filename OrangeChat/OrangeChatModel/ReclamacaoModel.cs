namespace OrangeChatModels;
public class ReclamacaoModel
{
	public string? Id { get; set; }
	public required string UsuarioId { get; set; }
	public required string CategoriaId { get; set; }
	public required string StatusId { get; set; }
	public required string Titulo { get; set; }
	public required string Descricao { get; set; }
	public DateTime DataAbertura { get; set; }
	public DateTime? DataFechamento { get; set; }

	public ReclamacaoModel()
	{
		Id = Guid.NewGuid().ToString();
		DataAbertura = DateTime.Now;
	}
}