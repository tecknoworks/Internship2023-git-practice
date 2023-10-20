using BusinessLayer.Models;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class PersonService : IPersonService
    {
        private SchoolDbContext schoolDbContext;
        public PersonService(SchoolDbContext schoolDbContext)
        {
            this.schoolDbContext = schoolDbContext;
        }


        //create person
        public async Task<Person?> CreatePerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            try
            {
                await schoolDbContext.Persons.AddAsync(person);
                await schoolDbContext.SaveChangesAsync();
                return person;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create new person", ex);
            }
        }

        //update person
        public async Task<Person?> UpdatePerson(int id, Person person)
        {
            try
            {
                schoolDbContext.Persons.Update(person);
                await schoolDbContext.SaveChangesAsync();
                return person;
            }catch (Exception ex)
            {
                throw new Exception("Person was updated.");
            }

            
        }


        //get person by id
              public async Task<Person?> GetPersonById(int id)
              {
                  Person personById= await schoolDbContext.Persons.FirstOrDefaultAsync(x => x.Id == id);
                  if (personById == null)
                  {
                      throw new ArgumentNullException(nameof(personById));
                  }
                  return personById;
              }

        public async Task<string> SaveChangesAsync()
        {
            await schoolDbContext.SaveChangesAsync();
            return "changes saved";
        }
     
    



    }
}
