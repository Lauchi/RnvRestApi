using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestAdapter.DomainHtos;

namespace RestAdapter.Controllers
{
    [Route("game-session")]
    public class GameSessionController : Controller
    {
        [HttpGet]
        public IEnumerable<GameSessionHto> GetGameSessions()
        {
            return new List<GameSessionHto>();
        }

        [HttpGet("{id}")]
        public GameSessionHto GetGameSession(int id)
        {
            return new GameSessionHto();
        }

        [HttpPost("{id}")]
        public GameSessionHto CreateGameSession()
        {
            //save to db, get id
            return new GameSessionHto();
        }
    }
}