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
        private IDbMapping _dbMapping;

        public GameSessionRepository(RnvScotlandYardContext db, IDbMapping dbMapping)
        {
            _db = db;
            _dbMapping = dbMapping;
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
                Name = policeOfficer.Name,
                CurrentStation = _dbMapping.StationMapper(policeOfficer.CurrentStation)
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
                Name = mrX.Name,
                LastKnownStation = _dbMapping.StationMapper(mrX.LastKnownStation)
            };
            gameSessionInDb.Mrx = mrxDb;
            await _db.SaveChangesAsync();
        }
    }
}