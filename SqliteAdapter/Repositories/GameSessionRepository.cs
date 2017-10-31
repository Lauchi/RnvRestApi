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
        private readonly RnvScotlandYardContext _db;

        public GameSessionRepository(RnvScotlandYardContext db)
        {
            _db = db;
        }

        public ICollection<GameSession> GetSessions()
        {
            var dbGameSessions = _db.GameSessions.Include(gs => gs.PoliceOfficers);
            var gameSessions = dbGameSessions.Select(dbSession => GameSessionMapper(dbSession)).ToList();
            return gameSessions;
        }

        public async Task Persist(GameSession gameSession)
        {
            var gameSessionDb = new GameSessionDb
            {
                GameSessionId = gameSession.GameSessionId.Id,
                Name = gameSession.Name,
                StartTime = gameSession.StartTime
            };
            _db.GameSessions.Add(gameSessionDb);
            await _db.SaveChangesAsync();
        }

        private GameSession GameSessionMapper(GameSessionDb gameSession)
        {
            var mrX = gameSession.Mrx != null
                ? new MrX(new MrXId(gameSession.Mrx.MrxId), gameSession.Mrx.Name)
                : null;
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