using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ValueTypes.Ids;
using Microsoft.AspNetCore.Mvc;
using RestAdapter.DomainHtos;
using SqliteAdapter.Repositories;

namespace RestAdapter.Controllers
{
    [Route("game-session")]
    public class GameSessionController : Controller
    {
        private IGameSessionRepository _gameSessionRepository;

        public GameSessionController(IGameSessionRepository gameSessionRepository)
        {
            _gameSessionRepository = gameSessionRepository;
        }

        [HttpGet]
        public IActionResult GetGameSessions()
        {
            var gameSessions = _gameSessionRepository.GetSessions();
            var gameSessionHtos = gameSessions.Select(session => new GameSessionHto(session));
            return Ok(gameSessionHtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetGameSession(string id)
        {
            var gameSession = _gameSessionRepository.GetSession(new GameSessionId(id));
            var gameSessionHto = new GameSessionHto(gameSession);
            return Ok(gameSessionHto);
        }

        [HttpPost]
        public async Task<GameSessionHto> CreateGameSession([FromQuery] string sessionName)
        {
            var gameSession = await _gameSessionRepository.Add(new GameSession(sessionName));
            return new GameSessionHto(gameSession);
        }
    }
}