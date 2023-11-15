using Microsoft.EntityFrameworkCore;
using SRMProject.Backend.TestTask.Entity;

namespace SRMProject.Backend.TestTask.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            try
            {
                Database.EnsureCreated();
            }catch (Exception)
            {

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(new Contact[]
            {
                new Contact { Id = Guid.NewGuid(), Name = "1", BirthDate = DateTime.Now, JobTitle = "1", MobilePhone = "19324323" },
                new Contact { Id = Guid.NewGuid(), Name = "2", BirthDate = DateTime.Now, JobTitle = "2", MobilePhone = "29224526" },
            });
        }
    }
}
