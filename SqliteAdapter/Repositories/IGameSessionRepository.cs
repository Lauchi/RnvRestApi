using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.ValueTypes.Ids;

namespace SqliteAdapter.Repositories
{
    public interface IGameSessionRepository
    {
        ICollection<GameSession> GetSessions();
        Task Persist(GameSession gameSession);
    }
}