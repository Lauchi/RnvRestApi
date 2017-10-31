using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Domain;
using Domain.ValueTypes.Ids;
using SqliteAdapter.Repositories;

namespace EventStoring
{
    public class EventStore : IEventStore
    {
        private readonly IGameSessionRepository _gameSessionRepository;
        private readonly IImmutableList<GameSession> _gameSessions;

        public EventStore(IGameSessionRepository gameSessionRepository)
        {
            _gameSessionRepository = gameSessionRepository;

            _gameSessions = _gameSessionRepository.GetSessions();
            GameSession.GameSessionCreated += OnGameSessionCreated;
            GameSession.MrxAdded += GameSessionOnMrxAdded;
            GameSession.PoliceOfficerAdded += GameSessionOnPoliceOfficerAdded;
        }

        private void GameSessionOnPoliceOfficerAdded(GameSession gameSession)
        {
            _gameSessionRepository.Persist(gameSession);
        }

        private void GameSessionOnMrxAdded(GameSession gameSession)
        {
            _gameSessionRepository.Persist(gameSession);
        }

        private void OnGameSessionCreated(GameSession gameSession)
        {
            _gameSessions.Add(gameSession);
            _gameSessionRepository.Persist(gameSession);
        }

        public IEnumerable<GameSession> GetSessions()
        {
            return _gameSessions;
        }

        public GameSession GetSession(GameSessionId gameSessionId)
        {
            var session = _gameSessions.FirstOrDefault(gs => gs.GameSessionId == gameSessionId);
            return session;
        }

        public MrX GetMrX(GameSessionId gameSessionId)
        {
            return GetSession(gameSessionId).MrX;
        }

        public IEnumerable<PoliceOfficer> GetPoliceOfficers(GameSessionId gameSessionId)
        {
            return GetSession(gameSessionId).PoliceOfficers;
        }
    }
}