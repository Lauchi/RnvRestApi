using Microsoft.AspNetCore.Mvc;
using RestAdapter.DomainHtos;

namespace RestAdapter.Controllers
{
    [Route("routes")]
    public class RouteController : Controller
    {
        [HttpGet]
        public RouteHto SearchStation()
        {
            return new RouteHto();
        }
    }
}