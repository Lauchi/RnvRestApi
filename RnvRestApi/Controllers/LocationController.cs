using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RnvRestApi.DomainDtos;
using RnvRestApi.rnvAdapter;

namespace RnvRestApi.Controllers
{
    [Route("station")]
    public class LocationController : Controller
    {

        [HttpGet("{id}")]
        public async Task<StationDto> Get(StationId id)
        {
            return new StationDto()
            {
                StationId = id
            };
        }

        [HttpGet]
        public async Task<StationDto> SearchStation([FromQuery] string name)
        {
            return new StationDto()
            {
                Name = name
            };
        }
    }
}