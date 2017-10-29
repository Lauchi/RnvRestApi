using System.Collections.Generic;
using RnvRestApi.Domain.ValueTypes.Ids;

namespace RnvRestApi.DomainDtos
{
    public class GameSessionDto
    {
        public GameSessionId GameSessionId { get; }
        public MrXId MrXId { get; }
        public IEnumerable<PoliceOfficerId> PoliceOfficers { get; }
    }
}