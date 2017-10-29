using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain;
using Domain.ValueTypes.Ids;
using SqliteAdapter.Model;

namespace SqliteAdapter.Repositories
{
    public class GameSessionRepository : IGameSessionRepository
    {
        public async Task<GameSession> Add(GameSession gameSession)
        {
            using (var db = new RnvScotlandYardContext())
            {
                var gameSessionDb = new GameSessionDb()
                {
                    GameSessionId = gameSession.GameSessionId.Id,
                    Mrx = null,
                    Name = gameSession.Name,
                    PoliceOfficers = null,
                    StartTime = gameSession.StartTime
                };
                db.GameSessions.Add(gameSessionDb);
                await db.SaveChangesAsync();
                return gameSession;
            }
        }

        public IEnumerable<GameSession> GetSessions()
        {
            using (var db = new RnvScotlandYardContext())
            {
                var gameSessions = db.GameSessions.Select(GameSessionMapper()).ToList();
                return gameSessions;
            }
        }

        private static Expression<Func<GameSessionDb, GameSession>> GameSessionMapper()
        {
            return gameSession =>
                new GameSession(
                    gameSession.Name,
                    new GameSessionId(gameSession.GameSessionId),
                    gameSession.StartTime,
                    new MrX(new MrXId(gameSession.Mrx.MrxId)),
                    gameSession.PoliceOfficers.Select(officer =>
                        new PoliceOfficer(new PoliceOfficerId(officer.PoliceOfficerId))).ToList());
        }

        public GameSession GetSession(GameSessionId searchId)
        {
            using (var db = new RnvScotlandYardContext())
            {
                var equalGameSessions = db.GameSessions.Where(session => session.GameSessionId == searchId.Id);
                var firstOrDefault = equalGameSessions.Select(GameSessionMapper()).FirstOrDefault();
                return firstOrDefault;
            }
        }
    }
}