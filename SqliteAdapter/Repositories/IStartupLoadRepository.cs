using System.Collections.Generic;
using Domain;

namespace SqliteAdapter.Repositories
{
    public interface IStartupLoadRepository
    {
        ICollection<GameSession> GetSessions();
        void LoadSessions();
    }
}