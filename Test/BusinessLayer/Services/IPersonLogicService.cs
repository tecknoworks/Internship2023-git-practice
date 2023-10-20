using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IPersonLogicService
    {
        public Task<Person> CreatePerson(Person person);
        public Task<Person?> UpdatePerson(int id, Person person);
        public Task<Person?> GetPersonById(int id);
        Task<string> SaveChangesAsync();
    }
}
