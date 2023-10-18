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
            return await _personDataService.CreatePersonAsync(newPerson);
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            return await _personDataService.GetPersonsAsync();
        }

        public async Task<Person?> GetPersonAsync(int personId)
        {
            return await _personDataService.GetPersonAsync(personId);
        }

        public async Task<Person> UpdatePersonAsync(int personId, Person updatedPerson)
        {
            return await _personDataService.UpdatePersonAsync(personId, updatedPerson);
        }

        public async Task SaveChangesAsync()
        {
            await _personDataService.SaveChangesAsync();
        }
    }
}
