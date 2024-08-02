using CommentPlugin_v2.Models;

namespace CommentPlugin_v2.DTOs
{
    public class CommentDto : Comment
    {
        //public int ObjectId { get; set; }
        //public string? ObjectTitle { get; set; }
        //public string ObjectUrl { get; set; }
        //public int ObjectType { get; set; }
        //public string Content { get; set; }
        //public string? SenderName { get; set; }
        //public string? SenderEmail { get; set; }
        //public string? SenderPhone { get; set; }
        public string? captcha { get; set; }
        public string? md5Captcha { get; set; }
    }
}
