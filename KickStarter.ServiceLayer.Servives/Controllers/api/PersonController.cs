using AutoMapper;
using KickStarter.BusinessLayer.Components.Interfaces;
using KickStarter.DataLayer.DI;
using KickStarter.Library.Entities;
using KickStarter.ServiceLayer.Controllers.api.Interfaces;
using KickStarter.ServiceLayer.Servives.ClientModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KickStarter.ServiceLayer.Controllers.api
{
    [Route("api/Person")]
    public class PersonController : BaseApiController, IPersonController
    {
       // private readonly Lazy<IReadOnlyRepository<Person>> _persosnRepository;
        private readonly Lazy<IGetPersonsComponent> _getPersonComponent;
        private readonly Lazy<ISavePersonComponent> _savePersonComponent;
        private readonly Lazy<IDeletePersonComponent> _deletePersonComponent;

        public PersonController(
            //Lazy<IReadOnlyRepository<Person>> personRepository,
            Lazy<IGetPersonsComponent> getPersonComponent,
            Lazy<ISavePersonComponent> savePersonComponent,
            Lazy<IDeletePersonComponent> deletePersonComponent)
        {
           // _persosnRepository = personRepository;
            _getPersonComponent = getPersonComponent;
            _savePersonComponent = savePersonComponent;
            _deletePersonComponent = deletePersonComponent;
        }

        /// <summary>
        /// Fetches a Person by its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetPersonById/{id:int}")]
        public async Task<IActionResult> GetPersonById(Guid id)
        {
            var person = await _getPersonComponent.Value.GetPersonById(id);
            if (person == null)
            {
                return new StatusCodeResult(204);
            }
            var result = Mapper.Map<Person, PersonModel>(person);
            return Ok(result);
        }

        /// <summary>
        /// Fetches a list of all Persons
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPersonsList")]
        public async Task<IActionResult> GetPersonsAsync()
        {
            var persons = await _getPersonComponent.Value.GetAllPersons();
            if (persons == null)
            {
                return new StatusCodeResult(204);
            }
            if (persons.Count == 0)
            {
                return new NoContentResult();   // No content
            }
            var result = Mapper.Map<IList<Person>, IList<PersonModel>>(persons);
            return Ok(result);
        }

        /// <summary>
        /// Saves a Personn to the repository.
        /// </summary>
        /// <param name="personSave"></param>
        /// <returns></returns>
        [HttpPost("SavePerson")]
        public async Task<IActionResult> SavePerson([FromBody] PersonModel personSave)
        {
            var mappedPerson = Mapper.Map<PersonModel, Person>(personSave);
            var savedPerson = await _savePersonComponent.Value.SavePerson(mappedPerson);
            if (savedPerson == null)
            {
                return StatusCode(500);
            }
            var returnUser = await _getPersonComponent.Value.GetPersonById(savedPerson.Id);
            var result = Mapper.Map<Person, PersonModel>(returnUser);
            return Ok(result);
        }

        /// <summary>
        /// Deletes a person from the repository.
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpPost("DeletePerson")]
        public async Task<IActionResult> DeletePerson(Guid personId)
        {
            var person = await _getPersonComponent.Value.GetPersonById(personId);
            if (person == null)
            {
                return new StatusCodeResult(204);
            }
            var output = await _deletePersonComponent.Value.DeletePerson(person.Id);
            return Ok();
        }

    }
}
