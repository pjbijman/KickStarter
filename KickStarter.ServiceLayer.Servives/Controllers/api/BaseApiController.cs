using KickStarter.ServiceLayer.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace KickStarter.ServiceLayer.Controllers.api
{
    [TypeFilter(typeof(ApiExceptionFilter))]
    public class BaseApiController : Controller
    {

    }
}
