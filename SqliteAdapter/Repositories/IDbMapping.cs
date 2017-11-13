using System.Threading.Tasks;
using Domain;
using Domain.ValueTypes;
using SqliteAdapter.Model;

namespace SqliteAdapter.Repositories
{
    public interface IDbMapping
    {
        MoveDb MoveMapper(Move move);
        Task<Move> MoveMapper(MoveDb moveDb);
        StationDb StationMapper(Station station);
        Station StationMapper(StationDb stationDb);
    }
}