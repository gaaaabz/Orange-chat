namespace OrangeRouteModel
{
    public class TagPostModel
    {
        public int? IdTagPost { get; set; }
        public int IdTag { get; set; }
        public TagModel? Tag { get; set; }
        public int IdTrilhaCarreira { get; set; }
        public TrilhaCarreiraModel? TrilhaCarreira { get; set; }
    }
}
