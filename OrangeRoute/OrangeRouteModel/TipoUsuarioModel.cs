namespace OrangeRouteModel
{
    public class TipoUsuarioModel
    {
        public int? IdTipoUsuario { get; set; }
        public required string Nome { get; set; }
        public List<UsuarioModel>? Usuarios { get; set; }
    }
}
