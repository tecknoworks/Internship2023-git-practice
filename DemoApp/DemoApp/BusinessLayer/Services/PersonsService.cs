using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class PersonsService : IPersonsService
    {
        private readonly IPersonsDataService _personDataService; 
        public PersonsService(IPersonsDataService personDataService) 
        {
            _personDataService = personDataService;
        }
        public async Task<Person> CreatePersonAsync(Person newPerson)
        {
            try 
            {
                return await _personDataService.CreatePersonAsync(newPerson);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<List<Person>> GetPersonsAsync()
        {
            try
            {
                return await _personDataService.GetPersonsAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Person> GetPersonAsync(int personId)
        {
            try 
            {
                return await _personDataService.GetPersonAsync(personId);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<Person> UpdatePersonAsync(int personId, Person updatedPerson)
        {
            try
            {
                return await _personDataService.UpdatePersonAsync(personId, updatedPerson);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _personDataService.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
