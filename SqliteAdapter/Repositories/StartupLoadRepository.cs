using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ValueTypes;
using Domain.ValueTypes.Ids;
using Microsoft.EntityFrameworkCore;
using RnvTriasAdapter;
using SqliteAdapter.Model;

namespace SqliteAdapter.Repositories
{
    public class StartupLoadRepository : IStartupLoadRepository
    {
        private RnvScotlandYardContext _db;
        private IRnvRepository _rnvRepository;
        private ICollection<GameSession> _gameSessions;
        private IDbMapping _dbMapping;

        public StartupLoadRepository(RnvScotlandYardContext db, IRnvRepository rnvRepository, IDbMapping dbMapping)
        {
            _db = db;
            _rnvRepository = rnvRepository;
            _dbMapping = dbMapping;
        }

        public ICollection<GameSession> GetSessions()
        {
            var sessionCopied = _gameSessions.ToList();
            return sessionCopied;
        }

        public async Task LoadSessions()
        {
            var dbGameSessions = _db.GameSessions
                .Include(gs => gs.PoliceOfficers)
                    .ThenInclude(po => po.MoveHistory)
                .Include(gs => gs.PoliceOfficers)
                    .ThenInclude(po => po.CurrentStation)
                .Include(gs => gs.Mrx)
                    .ThenInclude(po => po.MoveHistory)
                .Include(gs => gs.Mrx)
                    .ThenInclude(po => po.OpenMoves)
                .Include(gs => gs.Mrx)
                    .ThenInclude(po => po.LastKnownStation);
            _gameSessions = await Task.WhenAll(dbGameSessions.Select(dbSession => GameSessionMapper(dbSession)));
        }

        private async Task<GameSession> GameSessionMapper(GameSessionDb gameSession)
        {
            //Todo clean up this startup mapping crap
            var mrX = MrX.NullValue;
            if (gameSession.Mrx != null)
            {
                var moveHistory = (await Task.WhenAll(gameSession.Mrx.MoveHistory.Select(_dbMapping.MoveMapper))).ToList();
                var openMoves = (await Task.WhenAll(gameSession.Mrx.OpenMoves.Select(_dbMapping.MoveMapper))).ToList();
                var mappedStation = _dbMapping.StationMapper(gameSession.Mrx.LastKnownStation);
                var station = await _rnvRepository.GetStation(mappedStation.StationId);
                mrX = new MrX(new MrXId(gameSession.Mrx.MrxId), gameSession.Mrx.Name, openMoves, moveHistory, station);
            }

            ICollection<PoliceOfficer> policeOfficers = gameSession.PoliceOfficers.Select(officer =>
                new PoliceOfficer(new PoliceOfficerId(officer.PoliceOfficerId), officer.Name)).ToList();

            var session = new GameSession(
                gameSession.Name,
                gameSession.MaxPoliceOfficers,
                new GameSessionId(gameSession.GameSessionId),
                gameSession.StartTime,
                mrX,
                policeOfficers);
            return session;
        }
    }
}