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
    public class PersonLogicService: IPersonLogicService
    {
        private IPersonServices _personServices;

        public PersonLogicService(IPersonServices personService)
        {
            this._personServices = personService;
        }

        public async Task<string> CreatePersonLogic(Person person)
        {
            try
            {
                return await _personServices.CreatePerson(person);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong in CreateLogicPerson", ex);
            }
        }

        public async Task<string> UpdatePersonLogic(int id, Person person)
        {
            try
            {
                return await _personServices.UpdatePerson(id, person);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong in UpdatePersonLogic", ex);
            }
        }
    }
}
