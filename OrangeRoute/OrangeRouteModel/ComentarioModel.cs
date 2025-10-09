namespace OrangeRouteModel
{
    public class ComentarioModel
    {
        public int? IdComentario { get; set; }
        public required string Conteudo { get; set; }
        public int IdTrilhaCarreira { get; set; }
        public TrilhaCarreiraModel? TrilhaCarreira { get; set; }
        public int IdUsuario { get; set; }
        public UsuarioModel? Usuario { get; set; }
    }
}
