using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Validation;
using Domain.ValueTypes;
using Domain.ValueTypes.Ids;
using RnvTriasAdapter;
using SqliteAdapter.Repositories;

namespace EventStoring
{
    public class EventStore : IEventStore
    {
        private readonly IGameSessionRepository _gameSessionRepository;
        private readonly IRnvRepository _rnvRepository;
        private readonly ICollection<GameSession> _gameSessions;
        private readonly IMrxRepository _mrxRepository;

        public EventStore(IGameSessionRepository gameSessionRepository, IRnvRepository rnvRepository, IMrxRepository mrxRepository)
        {
            _gameSessionRepository = gameSessionRepository;
            _rnvRepository = rnvRepository;
            _mrxRepository = mrxRepository;

            _gameSessions = _gameSessionRepository.GetSessions();
            GameSession.GameSessionCreated += OnGameSessionCreated;
            GameSession.MrxAdded += GameSessionOnMrxAdded;
            GameSession.PoliceOfficerAdded += GameSessionOnPoliceOfficerAdded;
            GameSession.MrXDeleted += GameSessionOnMrXDeleted;
            GameSession.PoliceOfficerDeleted += GameSessionOnPoliceOfficerDeleted;
            PoliceOfficer.PoliceOfficerMoved += OnPoliceOfficerMoved;
            MrX.MrxMoved += MrXOnMrxMoved;
        }

        private void MrXOnMrxMoved(Move move, MrX mrX)
        {
            _mrxRepository.UpdateMrX(mrX);
        }

        private void OnPoliceOfficerMoved(Move move, PoliceOfficer policeOfficer)
        {
            throw new NotImplementedException();
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

        public async Task<Station> GetStation(StationId stationId)
        {
            var station = await _rnvRepository.GetStation(stationId);
            return station;
        }
    }
}