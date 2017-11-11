using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
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

        public async Task Add(GameSession gameSession)
        {
            var gameSessionDb = new GameSessionDb
            {
                GameSessionId = gameSession.GameSessionId.Id,
                Name = gameSession.Name,
                StartTime = gameSession.StartTime,
                Mrx = null,
                MaxPoliceOfficers = gameSession.MaxPoliceOfficers,
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
    }
}