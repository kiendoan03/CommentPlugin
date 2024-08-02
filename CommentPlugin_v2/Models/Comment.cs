namespace CommentPlugin_v2.Models
{
    public class Comment
    {
        //public int Id { get; set; }
        //public int? ParentId { get; set; }
        //public int ObjectId { get; set; }
        //public string? ObjectTitle { get; set; }
        //public string? ObjectType { get; set; }
        //public string? ObjectUrl { get; set; }
        //public string? SenderName { get; set; }
        //public string? SenderEmail { get; set; }
        //public string? SenderPhone { get; set; }
        //public string? ApproveBy { get; set; }
        //public string? Content { get; set; }
        //public int? Status { get; set; }
        //public DateTime? CreatedAt { get; set; }
        //public DateTime? LastModifiedAt { get; set;}
        //public DateTime? PublishedAt { get; set; }
        //public string? LasModifiedBy { get; set; }
        //public string? DeletedBy { get; set; }
        //public DateTime? DeletedAt { get; set; }
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public long ObjectId { get; set; }
        public string? ObjectTitle { get; set; }
        public string? ObjectUrl { get; set; }
        public int ObjectType { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Emotion { get; set; }
        public string? SenderEmail { get; set; }
        public string? SenderFullName { get; set; }
        public string? SenderAvatar { get; set; }
        public string? SenderAddress { get; set; }
        public string? SenderPhoneNumber { get; set; }
        public string? ApproveBy { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public long? ZoneId { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? Iplog { get; set; }
        public long? UserId { get; set; }
        public string? MailReplied { get; set; }
        public string? MailForwarded { get; set; }
    }
}
