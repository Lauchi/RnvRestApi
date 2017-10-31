using Domain;
using SqliteAdapter.Repositories;

namespace EventStoring
{
    public class EventStore : IEventStore
    {
        private readonly IGameSessionRepository _gameSessionRepository;

        public EventStore(IGameSessionRepository gameSessionRepository)
        {
            _gameSessionRepository = gameSessionRepository;
            //load all data
            GameSession.GameSessionCreated += GameSessionOnGameSessionCreated;
        }

        private void GameSessionOnGameSessionCreated(GameSession gameSession)
        {
            _gameSessionRepository.AddForEventStore(gameSession);
        }
    }
}