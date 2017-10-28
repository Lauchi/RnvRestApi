using Microsoft.AspNetCore.Mvc;
using RnvRestApi.DomainDtos;

namespace RnvRestApi.Controllers
{
    [Route("location")]
    public class LocationController : Controller
    {
        [HttpGet("{id}")]
        public StationDto Get(string id)
        {
            return new StationDto();
        }


        [HttpGet]
        public StationDto SearchStation([FromQuery] string name)
        {

            return new StationDto();
        }
    }
}