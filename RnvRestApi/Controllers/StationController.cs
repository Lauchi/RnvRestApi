using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RnvRestApi.DomainDtos;
using RnvRestApi.rnvAdapter;

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
        public async Task<StationDto> Get(StationId id)
        {
            return await _repository.GetStation(id);
        }

        [HttpGet]
        public async Task<StationDto> SearchStation([FromQuery] string name)
        {
            return await _repository.SearchStation(name);
        }
    }
}