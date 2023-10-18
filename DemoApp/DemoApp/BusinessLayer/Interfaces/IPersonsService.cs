using DataAccessLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IPersonsService
    {
        Task<IEnumerable<Person>> GetPersonsAsync();
        Task<Person?> GetPersonAsync(int personId);
        Task<Person> CreatePersonAsync(Person newPerson);
        Task<Person> UpdatePersonAsync(int personId, Person updatedPerson);
        Task SaveChangesAsync();
    }
}
