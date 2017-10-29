using Microsoft.AspNetCore.Mvc;
using RestAdapter.DomainHtos;

namespace RestAdapter.Controllers
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