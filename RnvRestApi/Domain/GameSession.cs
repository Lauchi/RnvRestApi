using System.Collections.Generic;
using RnvRestApi.Domain.ValueTypes.Ids;

namespace RnvRestApi.Domain
{
    public class GameSession
    {
        public GameSessionId GameSessionId { get; }
        public Gangster Gangster { get; }
        public IEnumerable<PoliceOfficer> PoliceOfficers { get; }
    }
}