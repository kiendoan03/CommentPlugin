namespace CommentPlugin.DTOs
{
    public class CommentCreateDto
    {
        public int PostId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }
        public string Content { get; set; }
    }
}
