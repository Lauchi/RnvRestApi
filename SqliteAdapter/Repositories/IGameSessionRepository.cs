using System.Collections.Immutable;
using System.Threading.Tasks;
using Domain;

namespace SqliteAdapter.Repositories
{
    public interface IGameSessionRepository
    {
        IImmutableList<GameSession> GetSessions();
        Task Persist(GameSession gameSession);
    }
}