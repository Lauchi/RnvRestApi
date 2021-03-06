﻿using Domain.ValueTypes.Ids;
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
            var mrX = _eventStore.GetMrX(new GameSessionId(gameSessionId), out var validationResult);
            if (!validationResult.Ok) return NotFound(validationResult);
            var mrXHto = new MrXHto(mrX);
            return Ok(mrXHto);
        }

        [HttpPost("{gameSessionId}/mr-x")]
        public IActionResult PostMrX(string gameSessionId, [FromBody] PlayerHtoPost playerPost)
        {
            var gameSession = _eventStore.GetSession(new GameSessionId(gameSessionId), out var validationResultSession);
            if (!validationResultSession.Ok)
            {
                return NotFound(validationResultSession);
            }

            var newMrX = gameSession.AddNewMrX(playerPost.Name, playerPost.StartLocation, out var validationResult);
            if (!validationResult.Ok)
            {
                return BadRequest(validationResult);
            }
            var mrXHto = new MrXHto(newMrX);
            return Created("weirdURis", mrXHto);
        }

        [HttpDelete("{gameSessionId}/mr-x")]
        public IActionResult DeleteMrX(string gameSessionId)
        {
            var gameSession = _eventStore.GetSession(new GameSessionId(gameSessionId), out var validationResultSession);
            if (!validationResultSession.Ok)
            {
                return NotFound(validationResultSession);
            }

            var validationResult = gameSession.MrX.Delete();
            if (!validationResult.Ok)
            {
                return BadRequest(validationResult);
            }
            return Ok();
        }
    }
}