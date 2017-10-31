using System.Collections.Immutable;
using Domain;
using Domain.ValueTypes.Ids;

namespace EventStoring
{
    public interface IEventStore
    {
        IImmutableList<GameSession> GetSessions();
        GameSession GetSession(GameSessionId gameSessionId);
    }
}