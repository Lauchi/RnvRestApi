using System.Linq;
using Domain;
using Domain.ValueTypes.Ids;
using Microsoft.AspNetCore.Mvc;
using RestAdapter.DomainHtos;
using SqliteAdapter.Repositories;

namespace RestAdapter.Controllers
{
    [Route("game-session")]
    public class PoliceOfficerController : Controller
    {
        private readonly IPoliceOfficerRepository _mrXRepository;

        public PoliceOfficerController(IPoliceOfficerRepository mrXRepository)
        {
            _mrXRepository = mrXRepository;
        }

        [HttpGet("{gameSessionId}/police-officer/{officerId}")]
        public IActionResult GetMrX(int gameSessionId)
        {
            var policeOfficers = _mrXRepository.GetPoliceOfficers(new GameSessionId(gameSessionId));
            if (policeOfficers == null) return NotFound();
            var policeOfficerHtos = policeOfficers.Select(policeOfficer => new PoliceOfficerHto(policeOfficer));
            return Ok(policeOfficerHtos);
        }

        [HttpPost("{gameSessionId}/police-officer/")]
        public IActionResult PostMrX(int gameSessionId, [FromBody] PlayerHtoPost playerPost)
        {
            var policeOfficer = _mrXRepository.AddPoliceOfficer(new PoliceOfficer(playerPost.Name), new GameSessionId(gameSessionId));
            if (policeOfficer == null)
            {
                return BadRequest();
            }
            return Ok(new PoliceOfficerHto(policeOfficer));
        }
    }
}