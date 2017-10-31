﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace SqliteAdapter.Repositories
{
    public interface IGameSessionRepository
    {
        ICollection<GameSession> GetSessions();
        Task Add(GameSession gameSession);
        Task AddPoliceOfficer(PoliceOfficer policeOfficer, GameSession gameSession);
        Task AddMrX(MrX mrX, GameSession gameSession);
        Task DeleteMrX(GameSession gameSession);
        Task DeletePoliceOfficer(PoliceOfficer policeOfficer);
    }
}