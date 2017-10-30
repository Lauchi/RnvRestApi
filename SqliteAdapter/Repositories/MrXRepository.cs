using System.Linq;
using Domain;
using Domain.ValueTypes.Ids;
using Microsoft.EntityFrameworkCore;
using SqliteAdapter.Model;

namespace SqliteAdapter.Repositories
{
    public class MrXRepository : IMrXRepository
    {
        private readonly RnvScotlandYardContext _db;

        public MrXRepository(RnvScotlandYardContext db)
        {
            _db = db;
        }

        public MrX GetMrX(GameSessionId gameSessionId)
        {
            var gameSession = _db.GameSessions.FirstOrDefault(gs => gs.GameSessionId == gameSessionId.Id);
            var gameSessionMrx = gameSession.Mrx;
            if (gameSessionMrx == null) return null;
            var mrX = new MrX(new MrXId(gameSessionMrx.MrxId), gameSessionMrx.Name);
            return mrX;
        }

        public MrX AddOrUpdateMrX(MrX mrXPost, GameSessionId gameSessionId)
        {
            var gameSessionDbs = _db.GameSessions.Include(gs => gs.Mrx);
            var gameSession = gameSessionDbs.FirstOrDefault(gs => gs.GameSessionId == gameSessionId.Id);
            if (gameSession.Mrx == null)
                gameSession.Mrx = new MrxDb
                {
                    Name = mrXPost.Name,
                    TicketPoolDb = new TicketPoolDb()
                };
            else
                gameSession.Mrx.Name = mrXPost.Name;
            _db.SaveChanges();

            var gameSessionMrx = gameSession.Mrx;
            var mrX = new MrX(new MrXId(gameSessionMrx.MrxId), gameSessionMrx.Name);
            return mrX;
        }
    }
}