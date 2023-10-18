using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Services
{
    public class PersonsDataService : IPersonsDataService
    {
        private readonly SchoolContext _context;

        public PersonsDataService(SchoolContext context)
        {
            _context = context;
        }

        public async Task<Person> CreatePersonAsync(Person newPerson) 
        {
            await _context.Persons.AddAsync(newPerson);
            await _context.SaveChangesAsync();
            return newPerson;
        }

        public async Task<Person?> GetPersonAsync(int personId)
        {
            return await _context.Persons.FirstOrDefaultAsync(person => person.Id == personId);
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Person> UpdatePersonAsync(int personId, Person updatedPerson)
        {
            _context.Persons.Update(updatedPerson);
            await _context.SaveChangesAsync();
            return updatedPerson;
        }
    }
}
