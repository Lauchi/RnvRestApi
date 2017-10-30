using Domain;
using Domain.ValueTypes.Ids;

namespace SqliteAdapter.Repositories
{
    public interface IMrXRepository
    {
        MrX GetMrX(GameSessionId gameSessionId);
        MrX AddOrUpdateMrX(MrX mrXPost, GameSessionId gameSessionId);
    }
}