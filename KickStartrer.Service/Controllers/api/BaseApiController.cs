using KickStartrer.Service.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace KickStartrer.Service.Controllers.api
{
    [TypeFilter(typeof(ApiExceptionFilter))]
    public class BaseApiController : Controller
    {

    }
}
