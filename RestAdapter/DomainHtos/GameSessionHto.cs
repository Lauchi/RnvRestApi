using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace RestAdapter.DomainHtos
{
    public class GameSessionHto
    {
        public GameSessionHto(GameSession gameSession)
        {
            Id = gameSession.GameSessionId.Id;
            Name = gameSession.Name;
            StartTime = gameSession.StartTime;
            MrXId = gameSession.MrX?.MrXId.Id;
            PoliceOfficerIds = gameSession.PoliceOfficers.Select(officer => officer.PoliceOfficerId.Id);
        }

        public string Id { get; }
        public string Name { get; }
        public DateTimeOffset StartTime { get; }
        public string MrXId { get; }
        public IEnumerable<string> PoliceOfficerIds { get; }
    }
}