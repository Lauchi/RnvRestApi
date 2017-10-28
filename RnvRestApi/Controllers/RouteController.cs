using Microsoft.AspNetCore.Mvc;
using RnvRestApi.DomainDtos;

namespace RnvRestApi.Controllers
{
    [Route("route")]
    public class RouteController : Controller
    {
        [HttpGet]
        public RouteDto SearchStation()
        {
            return new RouteDto();
        }
    }
}