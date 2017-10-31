using System.Collections.Generic;
using Domain;
using Domain.ValueTypes.Ids;

namespace EventStoring
{
    public interface IEventStore
    {
        IEnumerable<GameSession> GetSessions();
        GameSession GetSession(GameSessionId gameSessionId);
    }
}