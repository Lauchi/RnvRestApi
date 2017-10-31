using Domain;
using Domain.ValueTypes.Ids;
using Microsoft.AspNetCore.Mvc;
using RestAdapter.DomainHtos;
using SqliteAdapter.Repositories;

namespace RestAdapter.Controllers
{
    [Route("game-sessions")]
    public class MrXController : Controller
    {
        private readonly IMrXRepository _mrXRepository;

        public MrXController(IMrXRepository mrXRepository)
        {
            _mrXRepository = mrXRepository;
        }

        [HttpGet("{gameSessionId}/mr-x")]
        public IActionResult GetMrX(string gameSessionId)
        {
            var mrX = _mrXRepository.GetMrX(new GameSessionId(gameSessionId));
            if (mrX == null) return NotFound();
            var mrXHto = new MrXHto(mrX);
            return Ok(mrXHto);
        }

        [HttpPost("{gameSessionId}/mr-x")]
        public IActionResult PostMrX(string gameSessionId, [FromBody] PlayerHtoPost playerPost)
        {
            var mrX = _mrXRepository.AddOrUpdateMrX(new MrX(playerPost.Name), new GameSessionId(gameSessionId));
            if (mrX == null)
            {
                return BadRequest();
            }
            var mrXHto = new MrXHto(mrX);
            return Ok(mrXHto);
        }
    }
}