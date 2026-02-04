using Microsoft.EntityFrameworkCore;
using QuickStart.WepApi.Entity;

namespace QuickStart.WepApi.Context
{
    public class QuickStartContext : DbContext
    {
       
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseSqlServer(
                     "Server=GÖRKEM\\SQLEXPRESS;Database=QuickStartDb;Trusted_Connection=True;TrustServerCertificate=True"

                 );
        }
        public DbSet<Service> services { get; set; }
        public DbSet <Testimonial> testimonials{ get; set; }
    }
}
