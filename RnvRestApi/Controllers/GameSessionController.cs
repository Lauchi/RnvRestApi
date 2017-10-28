using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RnvRestApi.DomainDtos;

namespace RnvRestApi.Controllers
{
    [Route("game-session")]
    public class GameSessionController : Controller
    {
        [HttpGet]
        public IEnumerable<GameSessionDto> GetGameSessions()
        {
            return new List<GameSessionDto>();
        }

        [HttpGet("{id}")]
        public GameSessionDto GetGameSession(int id)
        {
            return new GameSessionDto();
        }
    }
}