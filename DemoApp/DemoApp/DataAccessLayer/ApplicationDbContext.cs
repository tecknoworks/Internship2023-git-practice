using BusinessLayer.Models;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class ApplicationDbContext : DbContext 
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Person> Persons { get; set; } 
        public DbSet<Student> Students { get; set; } 
        public DbSet<Teacher> Teachers { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(e => e.Student)
                .WithOne(e => e.Person)
                .HasForeignKey<Student>(e => e.PersonId)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .HasOne(e => e.Teacher)
                .WithOne(e => e.Person)
                .HasForeignKey<Teacher>(e => e.PersonId)
                .IsRequired();

           // base.OnModelCreating(modelBuilder);
        }
    }
}
