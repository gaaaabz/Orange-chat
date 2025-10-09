namespace OrangeRouteModel
{
    public class UsuarioModel
    {
        public int? IdUsuario { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public required string Telefone { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public int IdTipoUsuario { get; set; }
        public TipoUsuarioModel? TipoUsuario { get; set; }
        public List<FavoritosModel>? Favoritos { get; set; }
        public List<ComentarioModel>? Comentarios { get; set; }
    }
}
