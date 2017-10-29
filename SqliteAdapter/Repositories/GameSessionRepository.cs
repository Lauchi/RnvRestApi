using System.Threading.Tasks;
using Domain;
using SqliteAdapter.Model;

namespace SqliteAdapter.Repositories
{
    public class GameSessionRepository : IGameSessionRepository
    {
        public async Task<GameSession> Add(GameSession gameSession)
        {
            using (var db =new RnvScotlandYardContext())
            {
                var gameSessionDb = new GameSessionDb()
                {
                    GameSessionId = gameSession.GameSessionId.Id,
                    Mrx = null,
                    Name = gameSession.Name,
                    PoliceOfficers = null,
                    StartTime = gameSession.StartTime
                };
                db.GameSessions.Add(gameSessionDb);
                await db.SaveChangesAsync();
                return gameSession;
            }
        }
    }
}