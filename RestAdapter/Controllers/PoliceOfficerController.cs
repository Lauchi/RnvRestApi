﻿using System.Linq;
using Domain.ValueTypes.Ids;
using EventStoring;
using Microsoft.AspNetCore.Mvc;
using RestAdapter.DomainHtos;

namespace RestAdapter.Controllers
{
    [Route("game-sessions")]
    public class PoliceOfficerController : Controller
    {
        private readonly IEventStore _eventStore;

        public PoliceOfficerController(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        [HttpGet("{gameSessionId}/police-officers")]
        public IActionResult GetPoliceOfficer(string gameSessionId)
        {
            var policeOfficers = _eventStore.GetPoliceOfficers(new GameSessionId(gameSessionId), out var validationResult);
            if (!validationResult.Ok) return NotFound(validationResult);
            var policeOfficerHtos = policeOfficers.Select(policeOfficer => new PoliceOfficerHto(policeOfficer));
            return Ok(policeOfficerHtos);
        }

        [HttpPost("{gameSessionId}/police-officers")]
        public IActionResult PostPoliceOfficer(string gameSessionId, [FromBody] PlayerHtoPost playerPost)
        {
            var gameSession = _eventStore.GetSession(new GameSessionId(gameSessionId), out var validationResultSession);
            if (!validationResultSession.Ok)
            {
                return NotFound(validationResultSession);
            }

            var policeOfficer = gameSession.AddNewOfficer(playerPost.Name, playerPost.StartLocation, out var validationResult);
            if (!validationResult.Ok)
            {
                return BadRequest(validationResult);
            }
            return Created("weirdUri", new PoliceOfficerHto(policeOfficer));
        }

        [HttpGet("{gameSessionId}/police-officers/{policeOfficerId}")]
        public IActionResult GetPoliceOfficer(string gameSessionId, string policeOfficerId)
        {
            var gameSession = _eventStore.GetSession(new GameSessionId(gameSessionId), out var validationResult);
            if (!validationResult.Ok)
            {
                return NotFound(validationResult);
            }

            var policeOfficer = gameSession.GetPoliceOfficer(new PoliceOfficerId(policeOfficerId), out validationResult);
            if (!validationResult.Ok)
            {
                return NotFound(validationResult);
            }
            return Ok(new PoliceOfficerHto(policeOfficer));
        }

        [HttpDelete("{gameSessionId}/police-officers/{policeOfficerId}")]
        public IActionResult DeletePoliceOfficer(string gameSessionId, string policeOfficerId)
        {
            var gameSession = _eventStore.GetSession(new GameSessionId(gameSessionId), out var validationResult);
            if (!validationResult.Ok)
            {
                return NotFound(validationResult);
            }

            var policeOfficer = gameSession.GetPoliceOfficer(new PoliceOfficerId(policeOfficerId), out validationResult);
            policeOfficer.Delete();
            return Ok();
        }
    }
}