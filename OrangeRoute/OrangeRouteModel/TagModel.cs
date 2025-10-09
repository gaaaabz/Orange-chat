namespace OrangeRouteModel
{
    public class TagModel
    {
        public int? IdTag { get; set; }
        public required string Nome { get; set; }
        public List<TagPostModel>? TagPosts { get; set; }
    }
}
