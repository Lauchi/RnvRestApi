using System.Threading.Tasks;
using Domain;

namespace SqliteAdapter.Repositories
{
    public interface IGameSessionRepository
    {
        Task<GameSession> Add(GameSession gameSession);
    }
}