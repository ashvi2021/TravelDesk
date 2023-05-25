using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TravelDesk.Models
{
    public class ApplicationRequest
    {
        [Key]
        public int RequestId { get ; set; }  
        public int UserId { get; set; } //Foreign-key
        public string Location { get; set; }
        public int DepartmentId { get; set; }   //Foreign-key
        //public int ProjectId { get; set; }    //Foreign-key
        public int DocumentId { get; set; }   //Foreign-key
        public string ReasonForTravelling { get; set; }
        public string  DepartureCity { get; set; }   
        public string  DestinationCity { get; set; } 
        public DateTime  ? DepartureDate { get; set; }
        public int ? DurationOfTravel { get; set; }
        public Boolean ? HotelRequired { get; set; } 
        public int HotelId { get; set; }    //Foreign-key
        public Boolean ? MealNeeded { get; set; }
        public TravelMode TravelModel { get; set; }
        public int CommentId { get; set; }
        //foriegnkeyrefrence
        public User User { get; set; }   
        public Document Document { get; set; }
        public Hotel Hotel { get; set; }
        public Comment Comment { get; set; }
        public Department Department { get; set; }

        //public Project Project { get; set; }

    }
    public enum TravelMode
    {
        Domestic = 1,
        International = 2
    }
    
}
