using KickStartrer.Service.ClientModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace KickStartrer.Service.Controllers.api.Interfaces
{

    public interface IPersonController
    {
        Task<IActionResult> GetPersonsAsync();

        Task<IActionResult> GetPersonByIdAsync(Guid id);

        Task<IActionResult> SavePersonAsync([FromBody] PersonModel personSave);

        Task<IActionResult> DeletePersonAsync(Guid personId);

    }
}
