using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.ValueTypes.Ids;
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

        public PoliceOfficer AddPoliceOfficer(PoliceOfficer policeOfficerToAdd, GameSessionId gameSessionId)
        {
                var gameSession = _db.GameSessions.Include(gs => gs.PoliceOfficers).FirstOrDefault(gs => gs.GameSessionId == gameSessionId.Id);
                var officerDb = new PoliceOfficerDb
                {
                    Name = policeOfficerToAdd.Name,
                    TicketPoolDb = new TicketPoolDb()
                };
                gameSession.PoliceOfficers.Add(officerDb);

                _db.SaveChanges();

                var policeOfficer = new PoliceOfficer(new PoliceOfficerId(officerDb.PoliceOfficerId), officerDb.Name);
                return policeOfficer;
        }

        public IEnumerable<PoliceOfficer> GetPoliceOfficers(GameSessionId gameSessionId)
        {
                var gameSessionDbs = _db.GameSessions.Include(gs => gs.PoliceOfficers);
                var gameSession = gameSessionDbs.FirstOrDefault(gs => gs.GameSessionId == gameSessionId.Id);
                var policeOfficers = gameSession.PoliceOfficers;
                var officers = policeOfficers.Select(officer
                    => new PoliceOfficer(new PoliceOfficerId(officer.PoliceOfficerId), officer.Name)).ToList();
                return officers;
        }
    }
}