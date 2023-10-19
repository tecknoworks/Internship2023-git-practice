using BusinessLayer.Models;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            :  base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Person)
                .WithOne(p => p.Student)
                .HasForeignKey<Student>(s => s.PersonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Person)
                .WithOne(p => p.Teacher)
                .HasForeignKey<Teacher>(t => t.PersonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
