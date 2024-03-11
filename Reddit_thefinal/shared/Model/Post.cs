namespace shared.Model
{
    public class Post
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Date { get; set; }
        public string? Content { get; set; }
        public string? Username { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}