using Microsoft.EntityFrameworkCore;
using TravelDesk.Models;

namespace TravelDesk.Context
{
    public class TravelDeskDbContext : DbContext
    {
        public TravelDeskDbContext() 
        {

        }
        public TravelDeskDbContext(DbContextOptions<TravelDeskDbContext> options) : base(options) 
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<ApplicationRequest> applicationrequests { get; set; }  
        public DbSet<Comment> comments { get; set; }


    }
}
