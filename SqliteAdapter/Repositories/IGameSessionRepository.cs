using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.ValueTypes.Ids;

namespace SqliteAdapter.Repositories
{
    public interface IGameSessionRepository
    {
        Task<GameSession> Add(GameSession gameSession);
        IEnumerable<GameSession> GetSessions();
        GameSession GetSession(GameSessionId searchId);
    }
}