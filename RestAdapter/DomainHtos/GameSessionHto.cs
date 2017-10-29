using System.Collections.Generic;
using RnvRestApi.Domain.ValueTypes.Ids;

namespace RestAdapter.DomainHtos
{
    public class GameSessionHto
    {
        public GameSessionId GameSessionId { get; }
        public MrXId MrXId { get; }
        public IEnumerable<PoliceOfficerId> PoliceOfficers { get; }
    }
}