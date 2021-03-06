﻿using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using SqliteAdapter.Model;

namespace SqliteAdapter.Repositories
{
    public class MrxRepository : IMrxRepository
    {
        private readonly RnvScotlandYardContext _db;
        private readonly IDbMapping _dbMapping;

        public MrxRepository(RnvScotlandYardContext db, IDbMapping dbMapping)
        {
            _db = db;
            _dbMapping = dbMapping;
        }

        public void UpdateMrX(MrX mrX)
        {
            var mrxWithAllFields = _db.MrXs.Include(mr => mr.MoveHistory)
                .Include(mr => mr.OpenMoves);
            var mrxDb = mrxWithAllFields.SingleOrDefault(m => m.MrxId == mrX.MrXId.Id);

            mrxDb.Name = mrX.Name;
            if (mrX.LastKnownStation != null)
            {
                var stationFromDb = _db.Stations.SingleOrDefault(station => station.StationId == mrX.LastKnownStation.StationId.Id);
                mrxDb.LastKnownStation = stationFromDb ?? _dbMapping.StationMapper(mrX.LastKnownStation);
            }

            //Todo find a better way to reset the lists, this sucks
            foreach (var move in mrxDb.MoveHistory)
                _db.Moves.Remove(move);

            foreach (var move in mrxDb.OpenMoves)
                _db.Moves.Remove(move);

            mrxDb.MoveHistory = mrX.MoveHistory.Select(_dbMapping.MoveMapper).ToList();
            mrxDb.OpenMoves = mrX.OpenMoves.Select(_dbMapping.MoveMapper).ToList();

            _db.SaveChanges();
        }

        public async Task DeleteMrX(MrX mrX)
        {
            var mrxJoin = _db.MrXs.Include(mx => mx.MoveHistory).Include(mx => mx.OpenMoves);

            var mrxDb = mrxJoin.SingleOrDefault(gs => gs.MrxId == mrX.MrXId.Id);
            //Todo find a better way to reset the lists, this sucks
            foreach (var move in mrxDb.MoveHistory)
                _db.Moves.Remove(move);

            foreach (var move in mrxDb.OpenMoves)
                _db.Moves.Remove(move);
            _db.MrXs.Remove(mrxDb);

            await _db.SaveChangesAsync();
        }
    }
}