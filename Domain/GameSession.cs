using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Domain.Validation;
using Domain.ValueTypes.Ids;

namespace Domain
{
    public class GameSession
    {
        public static event Action<GameSession> GameSessionCreated;

        public static GameSession Create(string name, out DomainValidationResult result)
        {
            var session = new GameSession(name, new GameSessionId(Guid.NewGuid().ToString()));
            GameSessionCreated?.Invoke(session);
            result = DomainValidationResult.OkResult();
            return session;
        }

        private GameSession(string name, GameSessionId id)
        {
            Name = name;
            GameSessionId = id;
            PoliceOfficers = new Collection<PoliceOfficer>();
            StartTime = DateTimeOffset.Now;
            MrX = MrX.NullValue();
        }

        public GameSession(string name)
        {
            Name = name;
            PoliceOfficers = new Collection<PoliceOfficer>();
            StartTime = DateTimeOffset.Now;
            MrX = MrX.NullValue();

        }

        public GameSession(string name, GameSessionId id, DateTimeOffset startTime, MrX mrX, ICollection<PoliceOfficer> policeOfficers)
        {
            Name = name;
            GameSessionId = id;
            StartTime = startTime;
            MrX = mrX;
            PoliceOfficers = policeOfficers;
        }

        public GameSessionId GameSessionId { get; }
        public string Name { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public MrX MrX { get; private set; }
        public ICollection<PoliceOfficer> PoliceOfficers { get; }
    }
}