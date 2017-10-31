using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
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

        public IImmutableList<GameSession> GetSessions()
        {
            var dbGameSessions = _db.GameSessions.Include(gs => gs.PoliceOfficers).Include(gs => gs.Mrx);
            var gameSessions = dbGameSessions.Select(dbSession => GameSessionMapper(dbSession)).ToImmutableList();
            return gameSessions;
        }

        public async Task Persist(GameSession gameSession)
        {
            var gameSessionInDb = _db.GameSessions.SingleOrDefault(gs => gs.GameSessionId == gameSession.GameSessionId.Id);
            if (gameSessionInDb == null)
            {
                var gameSessionDb = new GameSessionDb
                {
                    GameSessionId = gameSession.GameSessionId.Id,
                    Name = gameSession.Name,
                    StartTime = gameSession.StartTime,
                    Mrx = null,
                    PoliceOfficers = new List<PoliceOfficerDb>()
                };
                _db.GameSessions.Add(gameSessionDb);
            }
            else
            {
                var mrX = gameSession.MrX;
                MrxDb mrxDb = null;
                if (mrX != null)
                    mrxDb = new MrxDb
                    {
                        MrxId = mrX.MrXId.Id,
                        Name = mrX.Name
                    };
                var policeOfficers = gameSession.PoliceOfficers.Select(officer => new PoliceOfficerDb
                {
                    Name = officer.Name,
                    PoliceOfficerId = officer.PoliceOfficerId.Id
                }).ToList();

                var gameSessionDb = new GameSessionDb
                {
                    GameSessionId = gameSession.GameSessionId.Id,
                    Name = gameSession.Name,
                    StartTime = gameSession.StartTime,
                    Mrx = mrxDb,
                    PoliceOfficers = policeOfficers
                };
                _db.GameSessions.Update(gameSessionDb);
            }

            await _db.SaveChangesAsync();
        }

        private GameSession GameSessionMapper(GameSessionDb gameSession)
        {
            var mrX = gameSession.Mrx != null
                ? new MrX(new MrXId(gameSession.Mrx.MrxId), gameSession.Mrx.Name)
                : null;
            ICollection<PoliceOfficer> policeOfficers = gameSession.PoliceOfficers.Select(officer =>
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