using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.ValueTypes;
using Microsoft.EntityFrameworkCore;
using SqliteAdapter.Model;
using Move = Domain.ValueTypes.Move;

namespace SqliteAdapter.Repositories
{
    public class PoliceOfficerRepository : IPoliceOfficerRepository
    {
        private RnvScotlandYardContext _db;
        private IDbMapping _dbMapping;

        public PoliceOfficerRepository(RnvScotlandYardContext db, IDbMapping dbMapping)
        {
            _db = db;
            _dbMapping = dbMapping;
        }

        public void UpdatePoliceOfficer(PoliceOfficer policeOfficer)
        {
            var mrxWithAllFields = _db.PoliceOfficers.Include(mr => mr.MoveHistory);
            var officerDb = mrxWithAllFields.SingleOrDefault(m => m.PoliceOfficerId == policeOfficer.PoliceOfficerId.Id);

            officerDb.Name = policeOfficer.Name;
            var officerStation = policeOfficer.CurrentStation;
            if (officerStation != null)
            {
                var stationDb = _db.Stations.Find(policeOfficer.CurrentStation.StationId.Id);
                officerDb.CurrentStation = stationDb ?? _dbMapping.StationMapper(officerStation);
            }

            if (policeOfficer.CurrentStation != null)
            {
                var stationFromDb = _db.Stations.SingleOrDefault(station => station.StationId == policeOfficer.CurrentStation.StationId.Id);
                officerDb.CurrentStation = stationFromDb ?? _dbMapping.StationMapper(policeOfficer.CurrentStation);
            }

            //Todo find a better way to reset the lists, this sucks
            foreach (var move in officerDb.MoveHistory)
            {
                _db.Moves.Remove(move);
            }

            officerDb.MoveHistory = policeOfficer.MoveHistory.Select(_dbMapping.MoveMapper).ToList();

            _db.SaveChanges();
        }

        public async Task DeletePoliceOfficer(PoliceOfficer policeOfficer)
        {
            var officerJoin = _db.PoliceOfficers.Include(officer => officer.MoveHistory);
            var policeOfficerDbs = officerJoin.SingleOrDefault(po => po.PoliceOfficerId == policeOfficer.PoliceOfficerId.Id);

            //Todo find a better way to reset the lists, this sucks
            foreach (var move in policeOfficerDbs.MoveHistory)
            {
                _db.Moves.Remove(move);
            }

            _db.PoliceOfficers.Remove(policeOfficerDbs);
            await _db.SaveChangesAsync();
        }
    }
}