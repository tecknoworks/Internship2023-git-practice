using BusinessLayer.Models;
using DataAccessLayer.Models;
using DataAccessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class PersonLogicService : IPersonLogicService
    {
        private IPersonService _personService;
        public PersonLogicService(IPersonService personService) { 
            this._personService = personService;
        }

        //create person
        public async Task<Person> CreatePerson(Person person)
        {
            try
            {
                var createdPerson = await _personService.CreatePerson(person);
                return createdPerson;
            }catch (Exception )
            {
                throw;
            }
        
        }

        //update user
        public async Task<Person?> UpdatePerson(int id, Person person)
        {
            try
            {
                Person personUpdate =await _personService.UpdatePerson(id,person);
                return personUpdate;
            }catch(Exception )
            {
                throw;
            }
            
        }

        //get person by id
        public async Task<Person?> GetPersonById(int id)
        {
            try
            {
                Person personById = await _personService.GetPersonById(id);
                return personById;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<string> SaveChangesAsync()
        {
            return await _personService.SaveChangesAsync();
        }




    }
}
