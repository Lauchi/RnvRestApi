using System.Collections.Generic;
using Domain;
using Domain.ValueTypes.Ids;

namespace SqliteAdapter.Repositories
{
    public interface IPoliceOfficerRepository
    {
        PoliceOfficer AddPoliceOfficer(PoliceOfficer policeOfficerToAdd, GameSessionId gameSessionId);
        IEnumerable<PoliceOfficer> GetPoliceOfficers(GameSessionId gameSessionId);
    }
}