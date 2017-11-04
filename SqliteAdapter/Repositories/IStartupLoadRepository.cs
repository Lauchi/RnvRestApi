using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace SqliteAdapter.Repositories
{
    public interface IStartupLoadRepository
    {
        Task<ICollection<GameSession>> GetSessions();
    }
}