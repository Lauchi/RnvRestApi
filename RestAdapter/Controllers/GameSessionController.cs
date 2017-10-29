using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
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
            return new List<GameSessionHto>();
        }

        [HttpGet("{id}")]
        public GameSessionHto GetGameSession(int id)
        {
            return new GameSessionHto(null);
        }

        [HttpPost("{sessionName}")]
        public async Task<GameSessionHto> CreateGameSession(string sessionName)
        {
            var gameSession = await _gameSessionRepository.Add(new GameSession(sessionName));
            return new GameSessionHto(gameSession);
        }
    }
}