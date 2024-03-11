namespace shared.Model
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? Username { get; set; }
        public string? Text { get; set; }
        public Post? Post { get; set; }
    }
}