namespace TravelDesk.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public enum Role
        {
            HRAdmin=1,
            Admin=2,
            Manager=3,
            Employee=4

        }
        public Role role { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }
        public string ContactNumber { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public bool ? IsActive { get; set; }



    }
}
