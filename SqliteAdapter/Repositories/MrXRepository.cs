using System.Linq;
using Domain;
using Domain.ValueTypes.Ids;
using SqliteAdapter.Model;

namespace SqliteAdapter.Repositories
{
    public class MrXRepository : IMrXRepository
    {
        public MrX GetMrX(GameSessionId gameSessionId)
        {
            using (var db = new RnvScotlandYardContext())
            {
                var gameSession = db.GameSessions.FirstOrDefault(gs => gs.GameSessionId == gameSessionId.Id);
                var gameSessionMrx = gameSession.Mrx;
                if (gameSessionMrx == null) return null;
                var mrX = new MrX(new MrXId(gameSessionMrx.MrxId), gameSessionMrx.Name);
                return mrX;
            }
        }

        public MrX AddMrX(MrX mrXPost, GameSessionId gameSessionId)
        {
            using (var db = new RnvScotlandYardContext())
            {
                var gameSession = db.GameSessions.FirstOrDefault(gs => gs.GameSessionId == gameSessionId.Id);
                gameSession.Mrx = new MrxDb()
                {
                    MrxId = mrXPost.MrXId.Id,
                    Name = mrXPost.Name,
                    TicketPoolDb = new TicketPoolDb()
                };
                db.SaveChanges();

                var gameSessionMrx = gameSession.Mrx;
                var mrX = new MrX(new MrXId(gameSessionMrx.MrxId), gameSessionMrx.Name);
                return mrX;
            }
        }
    }
}