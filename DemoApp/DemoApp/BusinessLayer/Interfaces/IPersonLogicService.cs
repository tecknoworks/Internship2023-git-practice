using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IPersonLogicService
    {
        Task<string> CreatePersonLogic(Person person);
        Task<string> UpdatePersonLogic(int id, Person person);
    }
}
