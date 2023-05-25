namespace TravelDesk.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string AdharCardNo { get; set; }

        public string? VisaNo { get; set; }
        public string? PassportNo { get; set; }
    }
}
