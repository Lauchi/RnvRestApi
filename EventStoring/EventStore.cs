﻿using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.ValueTypes.Ids;
using SqliteAdapter.Repositories;

namespace EventStoring
{
    public class EventStore : IEventStore
    {
        private readonly IGameSessionRepository _gameSessionRepository;
        private ICollection<GameSession> _gameSessions;

        public EventStore(IGameSessionRepository gameSessionRepository)
        {
            _gameSessionRepository = gameSessionRepository;
            _gameSessions = _gameSessionRepository.GetSessions();

            GameSession.GameSessionCreated += GameSessionOnGameSessionCreated;
        }

        private void GameSessionOnGameSessionCreated(GameSession gameSession)
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
    }
}