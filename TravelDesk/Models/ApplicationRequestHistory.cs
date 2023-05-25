using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace TravelDesk.Models
{
    public class ApplicationRequestHistory
    {

        //Getting User Id from User table
        //Getting Date from ApplicationRequest table
        //By Default RequestStatus is Pending 
        //All the Comments are Coming from the Comment table
        
        public int ApplicationRequestHistoryId { get; set; }     //primary key
        public string RequestStatus { get; set; } 
        public int ApplicationRequestId { get; set; }   //Foreign-Key
     

        //Refernce
        public ApplicationRequest ApplicationRequest { get; set; }
  


    }
}
