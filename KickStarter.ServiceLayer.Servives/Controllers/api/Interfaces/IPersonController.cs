using KickStarter.ServiceLayer.Servives.ClientModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KickStarter.ServiceLayer.Controllers.api.Interfaces
{

    public interface IPersonController
    {
        Task<IActionResult> GetPersons();

        Task<IActionResult> GetPersonById(int personId);

    }
}
