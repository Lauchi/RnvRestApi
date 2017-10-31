using System.Linq;
using Domain;
using Domain.ValueTypes.Ids;
using EventStoring;
using Microsoft.AspNetCore.Mvc;
using RestAdapter.DomainHtos;

namespace RestAdapter.Controllers
{
    [Route("game-sessions")]
    public class GameSessionController : Controller
    {
        private readonly IEventStore _eventStore;

        public GameSessionController(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        [HttpGet]
        public IActionResult GetGameSessions()
        {
            var gameSessions = _eventStore.GetSessions();
            var gameSessionHtos = gameSessions.Select(session => new GameSessionHto(session));
            return Ok(gameSessionHtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetGameSession(string id)
        {
            var gameSession = _eventStore.GetSession(new GameSessionId(id));
            if (gameSession == null)
            {
                return NotFound("Game Session not found");
            }
            var gameSessionHto = new GameSessionHto(gameSession);
            return Ok(gameSessionHto);
        }

        [HttpPost]
        public IActionResult CreateGameSession([FromBody] GameSessionHtoPost session)
        {
            var gameSession = GameSession.Create(session.Name, out var domainValidationResult);
            if (!domainValidationResult.Ok)
            {
                return BadRequest(domainValidationResult.ValidationErrors);
            }
            var gameSessionHto = new GameSessionHto(gameSession);
            return Ok(gameSessionHto);
        }
    }
}