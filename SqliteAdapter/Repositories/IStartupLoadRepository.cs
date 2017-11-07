using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace SqliteAdapter.Repositories
{
    public interface IStartupLoadRepository
    {
        ICollection<GameSession> GetSessions();
        Task LoadSessions();
    }
}