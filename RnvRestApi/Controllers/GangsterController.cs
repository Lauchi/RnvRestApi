using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RnvRestApi.Domain;
using RnvRestApi.Domain.ValueTypes.Ids;
using RnvTriasAdapter.DomainDtos;

namespace RnvRestApi.Controllers
{
    [Route("gangster")]
    public class GangsterController : Controller
    {
        [HttpGet("{id}")]
        public GangsterDto GetGangster(int id)
        {
            return new GangsterDto();
        }

        [HttpPost("{id}")]
        public GangsterDto PostGangster()
        {
            //save to db, get id
            return new GangsterDto();
        }
    }

    public class GangsterDto
    {
        public MrXId MrXId { get; }
        public IEnumerable<StationId> showedLocations { get; }
        public IEnumerable<VehicelType> usedVehicles { get; }
        public TicketPoolId TicketPoolId { get; }
    }
}