using Domain;
using Domain.ValueTypes.Ids;
using EventStoring;
using Microsoft.AspNetCore.Mvc;
using RestAdapter.DomainHtos;

namespace RestAdapter.Controllers
{
    [Route("game-sessions")]
    public class MrXController : Controller
    {
        private readonly IEventStore _eventStore;

        public MrXController(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        [HttpGet("{gameSessionId}/mr-x")]
        public IActionResult GetMrX(string gameSessionId)
        {
            var mrX = _eventStore.GetMrX(new GameSessionId(gameSessionId));
            if (mrX == MrX.NullValue) return NotFound("MrX not created on session");
            var mrXHto = new MrXHto(mrX);
            return Ok(mrXHto);
        }

        [HttpPost("{gameSessionId}/mr-x")]
        public IActionResult PostMrX(string gameSessionId, [FromBody] PlayerHtoPost playerPost)
        {
            var gameSession = _eventStore.GetSession(new GameSessionId(gameSessionId));
            var newMrX = gameSession.AddNewMrX(playerPost.Name, out var validationResult);
            if (!validationResult.Ok)
            {
                return BadRequest(validationResult.ValidationErrors);
            }
            var mrXHto = new MrXHto(newMrX);
            return Ok(mrXHto);
        }

        [HttpDelete("{gameSessionId}/mr-x")]
        public IActionResult DeleteMrX(string gameSessionId)
        {
            var gameSession = _eventStore.GetSession(new GameSessionId(gameSessionId));
            var validationResult = gameSession.MrX.Delete();
            if (!validationResult.Ok)
            {
                return BadRequest(validationResult.ValidationErrors);
            }
            return Ok();
        }
    }
}