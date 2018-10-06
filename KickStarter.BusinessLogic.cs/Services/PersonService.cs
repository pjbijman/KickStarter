using System;
using KickStarter.BusinessLogic.Interfaces;
using KickStarter.Library.Entities;

namespace KickStarter.BusinessLogic.Services
{
    public class PersonService : BaseBL, IPersonBLL
    {
        public PersonService()
        {

        }

        public Person GetById(Guid PersonId)
        {
            //Todo: Get data from the DAL.
            return new Person();
        }
    }
}
