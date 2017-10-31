using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ValueTypes.Ids;
using EventStoring;
using Microsoft.AspNetCore.Mvc;
using RestAdapter.DomainHtos;
using SqliteAdapter.Repositories;

namespace RestAdapter.Controllers
{
    [Route("game-sessions")]
    public class GameSessionController : Controller
    {
        private IGameSessionRepository _gameSessionRepository;
        private readonly IEventStore _eventStore;

        public GameSessionController(IGameSessionRepository gameSessionRepository, IEventStore eventStore)
        {
            _gameSessionRepository = gameSessionRepository;
            _eventStore = eventStore;
        }

        [HttpGet]
        public IActionResult GetGameSessions()
        {
            var gameSessions = _gameSessionRepository.GetSessions();
            var gameSessionHtos = gameSessions.Select(session => new GameSessionHto(session));
            return Ok(gameSessionHtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetGameSession(int id)
        {
            var gameSession = _gameSessionRepository.GetSession(new GameSessionId(id));
            if (gameSession == null)
            {
                return NotFound();
            }
            var gameSessionHto = new GameSessionHto(gameSession);
            return Ok(gameSessionHto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGameSession([FromBody] GameSessionHtoPost session)
        {
            var gameSession = await _gameSessionRepository.Add(new GameSession(session.Name));
            if (gameSession == null)
            {
                return BadRequest();
            }
            var gameSessionHto = new GameSessionHto(gameSession);
            return Ok(gameSessionHto);
        }

        [HttpPost("event-store")]
        public IActionResult CreateGameSessionEventStore([FromBody] GameSessionHtoPost session)
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