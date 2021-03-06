﻿using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.ValueTypes.Ids;
using Microsoft.EntityFrameworkCore;
using SqliteAdapter.Model;

namespace SqliteAdapter.Repositories
{
    public class StartupLoadRepository : IStartupLoadRepository
    {
        private RnvScotlandYardContext _db;
        private ICollection<GameSession> _gameSessions;
        private IDbMapping _dbMapping;

        public StartupLoadRepository(RnvScotlandYardContext db, IDbMapping dbMapping)
        {
            _db = db;
            _dbMapping = dbMapping;
        }

        public ICollection<GameSession> GetSessions()
        {
            var sessionCopied = _gameSessions.ToList();
            return sessionCopied;
        }

        public void LoadSessions()
        {
            var dbGameSessions = _db.GameSessions
                .Include(gs => gs.PoliceOfficers)
                    .ThenInclude(po => po.MoveHistory)
                .Include(gs => gs.PoliceOfficers)
                    .ThenInclude(po => po.MoveHistory)
                    .ThenInclude(po => po.Station)
                .Include(gs => gs.PoliceOfficers)
                    .ThenInclude(po => po.CurrentStation)
                .Include(gs => gs.Mrx)
                    .ThenInclude(po => po.MoveHistory)
                    .ThenInclude(po => po.Station)
                .Include(gs => gs.Mrx)
                    .ThenInclude(po => po.OpenMoves)
                    .ThenInclude(po => po.Station)
                .Include(gs => gs.Mrx)
                    .ThenInclude(po => po.LastKnownStation);
            _gameSessions = dbGameSessions.Select(dbSession => GameSessionMapper(dbSession)).ToList();
        }

        private GameSession GameSessionMapper(GameSessionDb gameSession)
        {
            //Todo clean up this startup mapping crap
            var mrX = MrX.NullValue;
            if (gameSession.Mrx != null)
            {
                var moveHistory = gameSession.Mrx.MoveHistory.Select(_dbMapping.MoveMapper).ToList();
                var openMoves = gameSession.Mrx.OpenMoves.Select(_dbMapping.MoveMapper).ToList();
                var mappedStation = _dbMapping.StationMapper(gameSession.Mrx.LastKnownStation);
                mrX = new MrX(new MrXId(gameSession.Mrx.MrxId), gameSession.Mrx.Name, moveHistory, openMoves, mappedStation);
            }

            ICollection<PoliceOfficer> policeOfficers = gameSession.PoliceOfficers.Select(officer =>
            {
                var moveHistory = officer.MoveHistory.Select(_dbMapping.MoveMapper).ToList();
                var mappedStation = _dbMapping.StationMapper(officer.CurrentStation);
                return new PoliceOfficer(new PoliceOfficerId(officer.PoliceOfficerId), officer.Name, moveHistory, mappedStation);
            }).ToList();

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