using System.Threading.Tasks;
using Domain;

namespace SqliteAdapter.Repositories
{
    public interface IPoliceOfficerRepository
    {
        void UpdatePoliceOfficer(PoliceOfficer policeOfficer);
        Task DeletePoliceOfficer(PoliceOfficer policeOfficer);
    }
}