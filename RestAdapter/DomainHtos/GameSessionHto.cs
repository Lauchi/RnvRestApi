using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.ValueTypes.Ids;

namespace RestAdapter.DomainHtos
{
    public class GameSessionHto
    {
        public GameSessionHto(GameSession gameSession)
        {
            GameSessionId = gameSession.GameSessionId;
            Name = gameSession.Name;
            StartTime = gameSession.StartTime;
            MrXId = gameSession.MrX.MrXId;
            PoliceOfficers = gameSession.PoliceOfficers.Select(officer => officer.PoliceOfficerId);
        }

        public GameSessionId GameSessionId { get; }
        public string Name { get; }
        public DateTimeOffset StartTime { get; }
        public MrXId MrXId { get; }
        public IEnumerable<PoliceOfficerId> PoliceOfficers { get; }
    }
}