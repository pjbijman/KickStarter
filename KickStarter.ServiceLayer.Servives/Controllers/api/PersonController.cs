using AutoMapper;
using KickStarter.BusinessLayer.Components.Interfaces;
using KickStarter.DataLayer.DI;
using KickStarter.Library.Entities;
using KickStarter.ServiceLayer.Controllers.api.Interfaces;
using KickStarter.ServiceLayer.Servives.ClientModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KickStarter.ServiceLayer.Controllers.api
{
    [Route("api/Person")]
    public class PersonController : BaseApiController, IPersonController
    {
        private readonly Lazy<IReadOnlyRepository<Person>> _persosnRepository;
        private readonly Lazy<IGetPersonComponent> _getPersonComponent;
        private readonly Lazy<ISavePersonComponent> _savePersonComponent;

        public PersonController(Lazy<IReadOnlyRepository<Person>> personRepository,
            Lazy<IGetPersonComponent> getPersonComponent,
            Lazy<ISavePersonComponent> savePersonComponent)
        {
            _persosnRepository = personRepository;
            _getPersonComponent = getPersonComponent;
            _savePersonComponent = savePersonComponent;
        }

        [HttpGet("GetPersonById/{id:int}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            var person = await _getPersonComponent.Value.Execute(id);
            if(person== null)
            {
                return new StatusCodeResult(204);
            }
            var result = Mapper.Map<Person, PersonModel>(person);
            return Ok(result) ;
        }

        public Task<IActionResult> GetPersons()
        {
            throw new NotImplementedException();
        }

    }
}
