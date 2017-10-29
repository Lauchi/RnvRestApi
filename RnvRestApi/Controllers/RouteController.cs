using Microsoft.AspNetCore.Mvc;
using RnvRestApi.DomainHtos;

namespace RnvRestApi.Controllers
{
    [Route("route")]
    public class RouteController : Controller
    {
        [HttpGet]
        public RouteHto SearchStation()
        {
            return new RouteHto();
        }
    }
}