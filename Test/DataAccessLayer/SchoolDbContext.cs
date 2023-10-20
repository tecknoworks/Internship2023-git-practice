using BusinessLayer.Models;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SchoolDbContext:DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
     : base(options)
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
        }

    }
}
