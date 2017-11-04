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

        public StartupLoadRepository(RnvScotlandYardContext db, IRnvRepository rnvRepository)
        {
            _db = db;
            _rnvRepository = rnvRepository;
        }

        public async Task<ICollection<GameSession>> GetSessions()
        {
            var dbGameSessions = _db.GameSessions.Include(gs => gs.PoliceOfficers).Include(gs => gs.Mrx);
            var gameSessions = await Task.WhenAll(dbGameSessions.Select(dbSession => GameSessionMapper(dbSession)));
            return gameSessions;
        }

        private async Task<GameSession> GameSessionMapper(GameSessionDb gameSession)
        {
            //Todo clean up this startup mapping crap
            var mrX = MrX.NullValue;
            if (gameSession.Mrx != null)
            {
                ICollection<Move> moveHistory = await Task.WhenAll(gameSession.Mrx.MoveHistory.Select(MoveMapper));
                ICollection<Move> openMoves = await Task.WhenAll(gameSession.Mrx.OpenMoves.Select(MoveMapper));
                mrX = new MrX(new MrXId(gameSession.Mrx.MrxId), gameSession.Mrx.Name, openMoves, moveHistory);
            }

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

        private async Task<Move> MoveMapper(MoveMrXDb moveDb)
        {
            var station = await _rnvRepository.GetStation(new StationId(moveDb.StationId));
            var move = new Move(station, Enum.Parse<VehicelType>(moveDb.VehicleType));
            return move;
        }

        private async Task<Move> MoveMapper(OpenMoveMrxDb moveDb)
        {
            var station = await _rnvRepository.GetStation(new StationId(moveDb.StationId));
            var move = new Move(station, Enum.Parse<VehicelType>(moveDb.VehicleType));
            return move;
        }
    }

    public interface IStartupLoadRepository
    {
        Task<ICollection<GameSession>> GetSessions();
    }
}