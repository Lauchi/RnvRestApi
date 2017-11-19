using System;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Validation;
using Domain.ValueTypes.Ids;
using EventStoring;
using Microsoft.AspNetCore.Mvc;
using RestAdapter.DomainHtos;

namespace RestAdapter.Controllers
{
    [Route("game-sessions")]
    public class PlayerController : Controller
    {
        private readonly IEventStore _eventStore;

        public PlayerController(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        [HttpPost("{gameSessionId}/players/{playerId}/move")]
        public async Task<IActionResult> MovePoliceOfficer(string gameSessionId, string playerId, [FromBody] MoveHtoPost movePost)
        {
            var gameSession = _eventStore.GetSession(new GameSessionId(gameSessionId), out var validationResult);
            if (!validationResult.Ok)
            {
                return NotFound(validationResult);
            }

            var station = await _eventStore.GetStation(new StationId(movePost.StationId));
            if (station == null)
            {
                return NotFound("Station not found");
            }

            var type = (VehicelType) Enum.Parse(typeof(VehicelType), movePost.VehicleType);

            if (gameSession.MrX.MrXId.Id == playerId)
            {
                validationResult = gameSession.MrX.Move(station, type);
            }
            else
            {
                var policeOfficer = (Player) gameSession.GetPoliceOfficer(new PoliceOfficerId(playerId), out validationResult);
                if (validationResult.Ok) validationResult = policeOfficer.Move(station, type);
            }

            if (!validationResult.Ok)
            {
                return NotFound(validationResult);
            }
            return Created("weirdURis", movePost);
        }
    }
}