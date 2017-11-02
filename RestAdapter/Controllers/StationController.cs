using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ValueTypes.Ids;
using Microsoft.AspNetCore.Mvc;
using RestAdapter.DomainHtos;
using RnvTriasAdapter;

namespace RestAdapter.Controllers
{
    [Route("stations")]
    public class StationController : Controller
    {
        private readonly IRnvRepository _repository;

        public StationController(IRnvRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var stationDto = await _repository.GetStation(new StationId(id));
            if (stationDto == null) return NotFound("Station not found");
            return Ok(new StationHto(stationDto));
        }

        [HttpGet]
        public async Task<IActionResult> SearchStation([FromQuery] string name, [FromQuery] double longitude, [FromQuery] double latitude)
        {
            IEnumerable<Station> stationDtos;
            if (name == null)
            {
                stationDtos = await _repository.SearchStation(new GeoLocation(longitude, latitude));
            }
            else
            {
                stationDtos = await _repository.SearchStation(name);
            }
            return Ok(stationDtos.Select(dto => new StationHto(dto)));
        }
    }
}