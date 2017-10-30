using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.ValueTypes.Ids;
using SqliteAdapter.Model;

namespace SqliteAdapter.Repositories
{
    public class PoliceOfficerRepository : IPoliceOfficerRepository
    {
        public PoliceOfficer AddPoliceOfficer(PoliceOfficer policeOfficerToAdd, GameSessionId gameSessionId)
        {
            using (var db = new RnvScotlandYardContext())
            {
                var gameSession = db.GameSessions.FirstOrDefault(gs => gs.GameSessionId == gameSessionId.Id);
                PoliceOfficerDb officerDb = new PoliceOfficerDb
                {
                    Name = policeOfficerToAdd.Name,
                    TicketPoolDb = new TicketPoolDb()
                };
                gameSession.PoliceOfficers.Add(officerDb);

                db.SaveChanges();

                var policeOfficer = new PoliceOfficer(new PoliceOfficerId(officerDb.PoliceOfficerId), officerDb.Name);
                return policeOfficer;
            }
        }

        public IEnumerable<PoliceOfficer> GetPoliceOfficers(GameSessionId gameSessionId)
        {
            using (var db = new RnvScotlandYardContext())
            {
                var gameSession = db.GameSessions.FirstOrDefault(gs => gs.GameSessionId == gameSessionId.Id);
                var policeOfficers = gameSession.PoliceOfficers;
                if (policeOfficers == null) return new List<PoliceOfficer>();
                var officers = policeOfficers.Select(officer
                    => new PoliceOfficer(new PoliceOfficerId(officer.PoliceOfficerId), officer.Name)).ToList();
                return officers;
            }
        }
    }
}