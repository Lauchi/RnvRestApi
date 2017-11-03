using System.Threading.Tasks;
using Domain;

namespace SqliteAdapter.Repositories
{
    public interface IMrxRepository
    {
        void UpdateMrX(MrX mrX);
        Task DeleteMrX(MrX mrX);
    }
}