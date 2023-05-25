namespace TravelDesk.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }    
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public MealPrefer? meal { get; set; }
        public NoOfMeals? noofmeal { get; set; }

    }
    public enum MealPrefer
    {
        Veg = 1,
        NonVeg = 2
    }
    public enum NoOfMeals
    {

        Lunch = 1,
        Dinner = 2,
        Both = 3,
    }
}
