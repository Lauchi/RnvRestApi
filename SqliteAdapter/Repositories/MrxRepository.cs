using System.Linq;
using Domain;
using Domain.ValueTypes;
using Microsoft.EntityFrameworkCore;
using SqliteAdapter.Model;

namespace SqliteAdapter.Repositories
{
    public class MrxRepository : IMrxRepository
    {
        private readonly RnvScotlandYardContext _db;

        public MrxRepository(RnvScotlandYardContext db)
        {
            _db = db;
        }

        public void UpdateMrX(MrX mrX)
        {
            var mrxWithAllFields = _db.MrXs.Include(mr => mr.MoveHistory)
                .Include(mr => mr.OpenMoves);
            var mrxDb = mrxWithAllFields.SingleOrDefault(m => m.MrxId == mrX.MrXId.Id);

            mrxDb.Name = mrX.Name;
            var mrXLastKnownStation = mrX.LastKnownStation;
            mrxDb.LastKnownStation = mrXLastKnownStation.StationId.Id;
            //Todo find a better way to reset the lists, this sucks
            foreach (var move in mrxDb.MoveHistory)
            {
                _db.MoveMrX.Remove(move);
            }

            foreach (var move in mrxDb.OpenMoves)
            {
                _db.OpenMoveMrx.Remove(move);
            }

            mrxDb.MoveHistory = mrX.MoveHistory.Select(MoveDbMapper).ToList();
            mrxDb.OpenMoves = mrX.OpenMoves.Select(OpenMoveDbMapper).ToList();

            _db.SaveChanges();
        }

        private MoveMrXDb MoveDbMapper(Move move)
        {
            var moveMovedToStation = move.MovedToStation;
            return new MoveMrXDb
            {
                StationId = moveMovedToStation.StationId.Id,
                VehicleType = move.Type.ToString()
            };
        }

        private OpenMoveMrxDb OpenMoveDbMapper(Move move)
        {
            var moveMovedToStation = move.MovedToStation;
            return new OpenMoveMrxDb
            {
                StationId = moveMovedToStation.StationId.Id,
                VehicleType = move.Type.ToString()
            };
        }
    }
}