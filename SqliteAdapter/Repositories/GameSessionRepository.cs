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
            var dbGameSessions = _db.GameSessions.Include(gs => gs.PoliceOfficers).Include(gs => gs.Mrx);
            var gameSessions = dbGameSessions.Select(dbSession => GameSessionMapper(dbSession)).ToList();
            return gameSessions;
        }

        public async Task Add(GameSession gameSession)
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

            await _db.SaveChangesAsync();
        }

        public async Task AddPoliceOfficer(PoliceOfficer policeOfficer, GameSession gameSession)
        {
            var gameSessionInDb = _db.GameSessions.SingleOrDefault(gs => gs.GameSessionId == gameSession.GameSessionId.Id);
            var policeOfficerDb = new PoliceOfficerDb
            {
                PoliceOfficerId = policeOfficer.PoliceOfficerId.Id,
                Name = policeOfficer.Name
            };
            gameSessionInDb.PoliceOfficers.Add(policeOfficerDb);
            await _db.SaveChangesAsync();
        }

        public async Task AddMrX(MrX mrX, GameSession gameSession)
        {
            var gameSessionInDb = _db.GameSessions.SingleOrDefault(gs => gs.GameSessionId == gameSession.GameSessionId.Id);
            var mrxDb = new MrxDb
            {
                MrxId = mrX.MrXId.Id,
                Name = mrX.Name
            };
            gameSessionInDb.Mrx = mrxDb;
            await _db.SaveChangesAsync();
        }

        public async Task DeletePoliceOfficer(PoliceOfficer policeOfficer)
        {
            var officerJoin = _db.PoliceOfficers.Include(officer => officer.MoveHistory);
            var policeOfficerDbs = officerJoin.SingleOrDefault(po => po.PoliceOfficerId == policeOfficer.PoliceOfficerId.Id);

            //Todo find a better way to reset the lists, this sucks
            foreach (var move in policeOfficerDbs.MoveHistory)
            {
                _db.MovePoliceOfficers.Remove(move);
            }

            _db.PoliceOfficers.Remove(policeOfficerDbs);
            await _db.SaveChangesAsync();
        }

        private GameSession GameSessionMapper(GameSessionDb gameSession)
        {
            //Todo clean up this startup mapping crap
            var mrX = gameSession.Mrx != null
                ? new MrX(new MrXId(gameSession.Mrx.MrxId), gameSession.Mrx.Name)
                : MrX.NullValue;
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