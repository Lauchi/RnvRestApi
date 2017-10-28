﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RnvRestApi.Domain;
using RnvRestApi.Domain.ValueTypes.Ids;
using RnvRestApi.DomainDtos;

namespace RnvRestApi.Controllers
{
    [Route("gangster")]
    public class GangsterController : Controller
    {
        [HttpGet("{id}")]
        public GangsterDto GetGameSession(int id)
        {
            return new GangsterDto();
        }

        [HttpPost("{id}")]
        public GangsterDto CreateGameSession()
        {
            //save to db, get id
            return new GangsterDto();
        }
    }

    public class GangsterDto
    {
        public GangsterId GangsterId { get; }
        public IEnumerable<StationId> showedLocations { get; }
        public IEnumerable<VehicelType> usedVehicles { get; }
        public TicketPoolId TicketPoolId { get; }
    }
}