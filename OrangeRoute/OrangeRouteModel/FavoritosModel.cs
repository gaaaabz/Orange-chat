namespace OrangeRouteModel
{
    public class FavoritosModel
    {
        public int? IdFavoritos { get; set; }
        public int IdUsuario { get; set; }
        public UsuarioModel? Usuario { get; set; }
        public List<TrilhaCarreiraModel>? Trilhas { get; set; }
    }
}
