using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RnvRestApi.DomainDtos;
using RnvRestApi.RnvAdapter;

namespace RnvRestApi.Controllers
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
        public async Task<StationDto> Get(string id)
        {
            return await _repository.GetStation(new StationId(id));
        }

        [HttpGet]
        public async Task<IEnumerable<StationDto>> SearchStation([FromQuery] string name)
        {
            return await _repository.SearchStation(name);
        }
    }
}