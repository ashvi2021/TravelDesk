namespace TravelDesk.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentName { get; set; }
        public string CommentGivenBy { get; set; }
        public DateTime? CommentTime { get; set; }
        public string Description { get; set; }
    }
}
