namespace OrangeRouteModel
{
    public class TrilhaCarreiraModel
    {
        public int? IdTrilhaCarreira { get; set; }
        public required string Conteudo { get; set; }
        public int? IdFavoritos { get; set; }
        public FavoritosModel? Favoritos { get; set; }
        public List<ComentarioModel>? Comentarios { get; set; }
        public List<TagPostModel>? TagsPost { get; set; }
    }
}
