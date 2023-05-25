namespace TravelDesk.Models
{
    public class User
    {
        public int UserId { get; set; }  //primary key
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
         
        public string Email { get; set; }
        public string Password { get; set; }

        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string DateOfBirth { get; set; }
        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public bool ? IsActive { get; set; }

       
        public int ManagerId { get; set; }
        public Role Role { get; set; }


    }

    public enum Role
    {
        HRAdmin = 1,
        Admin = 2,
        Manager = 3,
        Employee = 4

    }

}
