using System.Linq;
using Domain;
using Domain.ValueTypes;
using Microsoft.EntityFrameworkCore;
using SqliteAdapter.Model;

namespace SqliteAdapter.Repositories
{
    public class PoliceOfficerRepository : IPoliceOfficerRepository
    {
        private RnvScotlandYardContext _db;

        public PoliceOfficerRepository(RnvScotlandYardContext db)
        {
            _db = db;
        }

        public void UpdatePoliceOfficer(PoliceOfficer policeOfficer)
        {
            var mrxWithAllFields = _db.PoliceOfficers.Include(mr => mr.MoveHistory);
            var officerDb = mrxWithAllFields.SingleOrDefault(m => m.PoliceOfficerId == policeOfficer.PoliceOfficerId.Id);

            officerDb.Name = policeOfficer.Name;
            var mrXLastKnownStation = policeOfficer.CurrentStation;
            officerDb.CurrentStationId = mrXLastKnownStation.StationId.Id;
            //Todo find a better way to reset the lists, this sucks
            foreach (var move in officerDb.MoveHistory)
            {
                _db.MovePoliceOfficers.Remove(move);
            }

            officerDb.MoveHistory = policeOfficer.MoveHistory.Select(MoveDbMapper).ToList();

            _db.SaveChanges();
        }

        private MovePoliceOfficerDb MoveDbMapper(Move move)
        {
            var moveMovedToStation = move.MovedToStation;
            return new MovePoliceOfficerDb
            {
                StationId = moveMovedToStation.StationId.Id,
                VehicleType = move.Type.ToString()
            };
        }
    }
}