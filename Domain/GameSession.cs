using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Domain.ValueTypes.Ids;

namespace Domain
{
    public class GameSession
    {
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