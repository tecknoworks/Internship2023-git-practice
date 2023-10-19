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
            try
            {
                await _context.Persons.AddAsync(newPerson);
                await _context.SaveChangesAsync();
                return newPerson;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<Person> GetPersonAsync(int personId)
        {
            if (await _context.Persons.AnyAsync(x => x.Id == personId))
                throw new KeyNotFoundException($"Person with id {personId} does not exist.");
            
            return await _context.Persons.FirstOrDefaultAsync(person => person.Id == personId);

        }

        public async Task<List<Person>> GetPersonsAsync()
        {
            try
            {
                return await _context.Persons.ToListAsync();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<string> SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return "Changes saved to database.";
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
                _context.Persons.Update(updatedPerson);
                await _context.SaveChangesAsync();
                return updatedPerson;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
