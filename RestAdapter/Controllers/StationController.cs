using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestAdapter.DomainHtos;
using RnvTriasAdapter;
using RnvTriasAdapter.DomainDtos;

namespace RestAdapter.Controllers
{
    [Route("station")]
    public class StationController : Controller
    {
        private readonly IRnvRepository _repository;

        public StationController(IRnvRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<StationHto> Get(string id)
        {
            var stationDto = await _repository.GetStation(new StationId(id));
            return new StationHto(stationDto);
        }

        [HttpGet]
        public async Task<IEnumerable<StationHto>> SearchStation([FromQuery] string name)
        {
            var stationDtos = await _repository.SearchStation(name);
            return stationDtos.Select(dto => new StationHto(dto));
        }
    }
}