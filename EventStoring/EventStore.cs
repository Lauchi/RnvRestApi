using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Domain;
using Domain.Validation;
using Domain.ValueTypes.Ids;
using SqliteAdapter.Repositories;

namespace EventStoring
{
    public class EventStore : IEventStore
    {
        private readonly IGameSessionRepository _gameSessionRepository;
        private readonly ICollection<GameSession> _gameSessions;

        public EventStore(IGameSessionRepository gameSessionRepository)
        {
            _gameSessionRepository = gameSessionRepository;

            _gameSessions = _gameSessionRepository.GetSessions();
            GameSession.GameSessionCreated += OnGameSessionCreated;
            GameSession.MrxAdded += GameSessionOnMrxAdded;
            GameSession.PoliceOfficerAdded += GameSessionOnPoliceOfficerAdded;
            GameSession.MrXDeleted += GameSessionOnMrXDeleted;
            GameSession.PoliceOfficerDeleted += GameSessionOnPoliceOfficerDeleted;
        }

        private void GameSessionOnPoliceOfficerDeleted(PoliceOfficer policeOfficer)
        {
            _gameSessionRepository.DeletePoliceOfficer(policeOfficer);
        }

        private void GameSessionOnMrXDeleted(GameSession gameSession)
        {
            _gameSessionRepository.DeleteMrX(gameSession);
        }

        private void GameSessionOnPoliceOfficerAdded(PoliceOfficer policeOfficer, GameSession gameSession)
        {
            _gameSessionRepository.AddPoliceOfficer(policeOfficer, gameSession);
        }

        private void GameSessionOnMrxAdded(MrX mrX, GameSession gameSession)
        {
            _gameSessionRepository.AddMrX(mrX, gameSession);
        }

        private void OnGameSessionCreated(GameSession gameSession)
        {
            _gameSessions.Add(gameSession);
            _gameSessionRepository.Add(gameSession);
        }

        public IEnumerable<GameSession> GetSessions()
        {
            return _gameSessions;
        }

        public GameSession GetSession(GameSessionId gameSessionId, out DomainValidationResult validationResult)
        {
            var session = _gameSessions.FirstOrDefault(gs => gs.GameSessionId == gameSessionId);
            validationResult = session == null ? new DomainValidationResult("Game Session not found") : DomainValidationResult.OkResult();
            return session;
        }

        public MrX GetMrX(GameSessionId gameSessionId, out DomainValidationResult validationResult)
        {
            var gameSession = GetSession(gameSessionId, out validationResult);
            return !validationResult.Ok ? null : gameSession.MrX;
        }

        public IEnumerable<PoliceOfficer> GetPoliceOfficers(GameSessionId gameSessionId, out DomainValidationResult validationResult)
        {
            var gameSession = GetSession(gameSessionId, out validationResult);
            return !validationResult.Ok ? null : gameSession.PoliceOfficers;
        }
    }
}