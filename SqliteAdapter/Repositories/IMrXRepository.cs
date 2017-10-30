using Domain;
using Domain.ValueTypes.Ids;

namespace SqliteAdapter.Repositories
{
    public interface IMrXRepository
    {
        MrX GetMrX(GameSessionId gameSessionId);
        MrX AddMrX(MrX mrXPost, GameSessionId gameSessionId);
    }
}