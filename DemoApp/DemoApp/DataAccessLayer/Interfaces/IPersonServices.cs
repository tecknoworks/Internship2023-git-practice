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
        Task<string> CreatePerson(Person person);
        Task<string> UpdatePerson(int id, Person person);
    }
}
