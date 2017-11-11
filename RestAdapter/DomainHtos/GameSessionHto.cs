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
            MaxPoliceOfficers = gameSession.MaxPoliceOfficers;
            StartTime = gameSession.StartTime;
            MrXId = gameSession.MrX == MrX.NullValue ? null : gameSession.MrX.MrXId.Id;
            PoliceOfficerIds = gameSession.PoliceOfficers.Select(officer => officer.PoliceOfficerId.Id);
        }

        public string Id { get; }
        public int MaxPoliceOfficers { get; }
        public string Name { get; }
        public DateTimeOffset StartTime { get; }
        public string MrXId { get; }
        public IEnumerable<string> PoliceOfficerIds { get; }
    }
}