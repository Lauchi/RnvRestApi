using System.Collections.Generic;
using RestAdapter.Ids;

namespace RestAdapter.DomainHtos
{
    public class GameSessionHto
    {
        public GameSessionId GameSessionId { get; }
        public MrXId MrXId { get; }
        public IEnumerable<PoliceOfficerId> PoliceOfficers { get; }
    }
}