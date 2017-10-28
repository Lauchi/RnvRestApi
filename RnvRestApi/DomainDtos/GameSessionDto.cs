using System.Collections.Generic;
using RnvRestApi.Domain.ValueTypes.Ids;

namespace RnvRestApi.DomainDtos
{
    public class GameSessionDto
    {
        public GameSessionId GameSessionId { get; }
        public GangsterId GangsterId { get; }
        public IEnumerable<PoliceOfficerId> PoliceOfficers { get; }
    }
}