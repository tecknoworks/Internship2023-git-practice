using BusinessLayer.Models;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class PersonServices:IPersonServices
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public PersonServices(ApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Person> CreatePerson(Person person)
        {
            if (person == null) { 
                throw new ArgumentNullException("Person object is null");
            }
            try
            {
                await _applicationDbContext.Persons.AddAsync(person);
                await _applicationDbContext.SaveChangesAsync();

                return person;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong in Data layer -> Person", ex);
            }

        }

        public async Task<Person> UpdatePerson(int id, Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("Person object is null");
            }
            if(id <= 0) {
                throw new Exception("Id must be greater than 0");
            }
            try
            {
                Person searchedPerson = await _applicationDbContext.Persons.FindAsync(id)
                    ?? throw new Exception("Person ot found");

                searchedPerson.Name = person.Name != null ? person.Name : searchedPerson.Name;
                searchedPerson.Age = person.Age != null ? person.Age : searchedPerson.Age;
                searchedPerson.Gender = person.Gender != null ? person.Gender : searchedPerson.Gender;

                await _applicationDbContext.SaveChangesAsync();

                return person;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong in Data layer -> Person", ex);
            }
        }
    }
}
