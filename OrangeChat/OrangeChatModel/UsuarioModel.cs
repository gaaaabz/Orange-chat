namespace UsuarioModel;
public class UsuarioModel
{
    public string? Id { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string Senha { get; set; }
    public string? Telefone { get; set; }
    public required string Tipo { get; set; } // cliente, atendente, admin
    public DateTime DataCriacao { get; set; }

    public UsuarioModel()
    {
        Id = Guid.NewGuid().ToString();
        DataCriacao = DateTime.Now;
    }
}