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
        public IEnumerable<GameSessionHto> GetGameSessions()
        {
            var gameSessions = _gameSessionRepository.GetSessions();
            return gameSessions.Select(session => new GameSessionHto(session));
        }

        [HttpGet("{id}")]
        public GameSessionHto GetGameSession(string id)
        {
            var gameSession = _gameSessionRepository.GetSession(new GameSessionId(id));
            return new GameSessionHto(gameSession);
        }

        [HttpPost]
        public async Task<GameSessionHto> CreateGameSession([FromQuery] string sessionName)
        {
            var gameSession = await _gameSessionRepository.Add(new GameSession(sessionName));
            return new GameSessionHto(gameSession);
        }
    }
}