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

        public DbSet<ApplicationRequestHistory> applicationrequestsHistory { get; set; }

        public DbSet<Department> department { get; set; }
        public DbSet<Document> documents { get; set; }
        public DbSet<HistoryDetails> historyDetails { get; set; }
        public DbSet<Hotel> hotel { get; set; }
        public DbSet<Login> login { get; set; }

        //public DbSet<Project> projects { get; set; }



    }
}
