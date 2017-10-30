using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ValueTypes.Ids;
using Microsoft.EntityFrameworkCore;
using SqliteAdapter.Model;

namespace SqliteAdapter.Repositories
{
    public class GameSessionRepository : IGameSessionRepository
    {
        public async Task<GameSession> Add(GameSession gameSession)
        {
            using (var db = new RnvScotlandYardContext())
            {
                var gameSessionDb = new GameSessionDb
                {
                    Name = gameSession.Name,
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
                var dbGameSessions = db.GameSessions.Include(gs => gs.PoliceOfficers);
                var gameSessions = dbGameSessions.Select(dbSession => GameSessionMapper(dbSession)).ToList();
                return gameSessions;
            }
        }

        public GameSession GetSession(GameSessionId searchId)
        {
            using (var db = new RnvScotlandYardContext())
            {
                var gameSessionDbs = db.GameSessions.Include(gs => gs.PoliceOfficers);
                var equalGameSessions = gameSessionDbs.Where(session => session.GameSessionId == searchId.Id);
                var firstOrDefault = equalGameSessions.Select(dbSession => GameSessionMapper(dbSession)).FirstOrDefault();
                return firstOrDefault;
            }
        }

        private GameSession GameSessionMapper(GameSessionDb gameSession)
        {
            var mrX = gameSession.Mrx != null ? new MrX(new MrXId(gameSession.Mrx.MrxId), gameSession.Mrx.Name) : MrX.NullValue();
            var policeOfficers = gameSession.PoliceOfficers.Select(officer =>
                new PoliceOfficer(new PoliceOfficerId(officer.PoliceOfficerId), officer.Name)).ToList();
            var session = new GameSession(
                gameSession.Name,
                new GameSessionId(gameSession.GameSessionId),
                gameSession.StartTime,
                mrX,
                policeOfficers);
            return session;
        }
    }
}