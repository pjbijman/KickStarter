using KickStarter.ServiceLayer.Servives.ClientModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KickStarter.ServiceLayer.Controllers.api.Interfaces
{

    public interface IPersonController
    {
        Task<IActionResult> GetPersonsAsync();

        Task<IActionResult> GetPersonById(Guid personId);

        Task<IActionResult> SavePerson([FromBody] PersonModel personSave);

        Task<IActionResult> DeletePerson(Guid personId);

    }
}
