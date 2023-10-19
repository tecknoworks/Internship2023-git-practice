using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IPersonServices
    {
        Task<Person> CreatePerson(Person person);
        Task<Person> UpdatePerson(int id, Person person);
    }
}
