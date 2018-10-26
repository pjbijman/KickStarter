using AutoMapper;
using KickStarter.BusinessLayer.Components.Interfaces;
using KickStarter.Library.Entities;
using KickStartrer.Service.ClientModels;
using KickStartrer.Service.Controllers.api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KickStartrer.Service.Controllers.api
{
    /// <summary>
    /// Person AIP controller.
    /// </summary>
    [Route("api/[controller]")]
    public class PersonController : BaseApiController, IPersonController
    {
        private readonly Lazy<IGetPersonsComponent> _getPersonComponent;
        private readonly Lazy<ISavePersonComponent> _savePersonComponent;
        private readonly Lazy<IDeletePersonComponent> _deletePersonComponent;

        /// <summary>
        /// PersonController constructor
        /// </summary>
        /// <param name="getPersonComponent"></param>
        /// <param name="savePersonComponent"></param>
        /// <param name="deletePersonComponent"></param>
        public PersonController(
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
        [HttpGet("GetPersonByIdAsync/{id}")]
        public async Task<IActionResult> GetPersonByIdAsync(Guid id)
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
        [HttpGet("GetPersonsAsync")]
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
        [HttpPost("SavePersonAsync")]
         public async Task<IActionResult> SavePersonAsync([FromBody] PersonModel personSave) 
        {
            var mappedPerson = Mapper.Map<PersonModel, Person>(personSave);
            //Validate mapped Person
            var savedPerson = await _savePersonComponent.Value.SavePerson(mappedPerson);
            if (savedPerson == null)
            {
                return StatusCode(500);
            }
            var returnPerson = await _getPersonComponent.Value.GetPersonById(savedPerson.Id);
            var result = Mapper.Map<Person, PersonModel>(returnPerson);
            return Ok(result);
        }

        /// <summary>
        /// Deletes a person from the repository.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeletePersonAsync/{id}")]
        public async Task<IActionResult> DeletePersonAsync(Guid id)
        {
            var person = await _getPersonComponent.Value.GetPersonById(id);
            if (person == null)
            {
                return new StatusCodeResult(204);
            }
            var output = await _deletePersonComponent.Value.DeletePerson(person.Id);
            return Ok();
        }

    }
}
