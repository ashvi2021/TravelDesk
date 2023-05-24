using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TravelDesk.Models
{
    public class ApplicationRequest
    {
        [Key]
       public int RequestId { get ; set; }
       public int UserId { get; set; }
        public User User { get; set; }

        public string ? DeptName { get ; set; }

        public string ? ManagerName { get; set; }

        public string ? DepartureCity { get; set; }   
        public string ? DestinationCity { get; set; } 
        public DateTime  ? DepartureDate { get; set; }
        public DateTime  ? ArrivalDate { get; set; }
        public DateTime  ? DepartureTimeSlot { get; set; }
        public DateTime  ? ArrivalTimeSlot { get; set; }
        public int ? DurationOfTravel { get; set; }

        public string ? AdharCardNo { get; set; }
        
        public string ? VisaCode { get; set;}
        public string ?  PassportCode { get; set;}
        public Boolean ? HotelRequired { get; set; }  
        public Boolean ? MealNeeded { get; set; } 
         
        public enum MealPrefer
        {
            Veg=1,
            Vegan=2,
            NonVeg=3
        }
        public MealPrefer? meal { get; set; }
        public enum NoOfMeals
        {
            All=1,
            Breakfast=2,
            Brunch=3,
            Lunch=4,
            Snacks=5,
            Dinner=5
        }
        public NoOfMeals? noofmeal { get; set; } 

        public string Comments { get; set; }
        public Comment Comment { get; set; }    

     

    }
}
