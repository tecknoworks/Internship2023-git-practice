using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IPersonsDataService
    {
        Task<List<Person>> GetPersonsAsync();
        Task<Person> GetPersonAsync(int personId);
        Task<Person> CreatePersonAsync(Person newPerson);
        Task<Person> UpdatePersonAsync(int personId, Person updatedPerson);
        Task<string> SaveChangesAsync();
    }
}
