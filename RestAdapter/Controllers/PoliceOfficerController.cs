using System.Linq;
using Domain.ValueTypes.Ids;
using EventStoring;
using Microsoft.AspNetCore.Mvc;
using RestAdapter.DomainHtos;

namespace RestAdapter.Controllers
{
    [Route("game-sessions")]
    public class PoliceOfficerController : Controller
    {
        private readonly IEventStore _eventStore;

        public PoliceOfficerController(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        [HttpGet("{gameSessionId}/police-officers")]
        public IActionResult GetPoliceOfficer(string gameSessionId)
        {
            var policeOfficers = _eventStore.GetPoliceOfficers(new GameSessionId(gameSessionId), out var validationResult);
            if (!validationResult.Ok) return NotFound(validationResult.ErrorMessage);
            var policeOfficerHtos = policeOfficers.Select(policeOfficer => new PoliceOfficerHto(policeOfficer));
            return Ok(policeOfficerHtos);
        }

        [HttpPost("{gameSessionId}/police-officers")]
        public IActionResult PostPoliceOfficer(string gameSessionId, [FromBody] PlayerHtoPost playerPost)
        {
            var gameSession = _eventStore.GetSession(new GameSessionId(gameSessionId), out var validationResultSession);
            if (!validationResultSession.Ok)
            {
                return NotFound(validationResultSession.ErrorMessage);
            }

            var policeOfficer = gameSession.AddNewOfficer(playerPost.Name, out var validationResult);
            if (!validationResult.Ok)
            {
                return BadRequest(validationResult.ErrorMessage);
            }
            return Ok(new PoliceOfficerHto(policeOfficer));
        }

        [HttpDelete("{gameSessionId}/police-officers/{policeOfficerId}")]
        public IActionResult DeletePoliceOfficerMrX(string gameSessionId, string policeOfficerId)
        {
            var gameSession = _eventStore.GetSession(new GameSessionId(gameSessionId), out var validationResult);
            if (!validationResult.Ok)
            {
                return NotFound(validationResult.ErrorMessage);
            }

            var policeOfficer = gameSession.GetPoliceOfficer(new PoliceOfficerId(policeOfficerId), out validationResult);
            validationResult = policeOfficer.Delete();
            if (!validationResult.Ok)
            {
                return BadRequest(validationResult.ErrorMessage);
            }
            return Ok();
        }
    }
}