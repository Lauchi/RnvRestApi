﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Domain.Validation;
using Domain.ValueTypes;
using Domain.ValueTypes.Ids;
using static Domain.ValueTypes.WinnerEnum;

namespace Domain
{
    public class GameSession
    {
        private GameSession(string name, int maxPoliceOfficers, GameSessionId id)
        {
            Name = name;
            MaxPoliceOfficers = maxPoliceOfficers;
            GameSessionId = id;
            PoliceOfficers = new Collection<PoliceOfficer>();
            StartTime = DateTimeOffset.Now;
            MrX = MrX.NullValue;
            PlayerWinning = null;
            Winner = None;
        }

        public GameSession(string name, int maxPoliceOfficers, GameSessionId id, DateTimeOffset startTime, MrX mrX,
            ICollection<PoliceOfficer> policeOfficers)
        {
            Name = name;
            GameSessionId = id;
            StartTime = startTime;
            MrX = mrX;
            PoliceOfficers = policeOfficers;
            MaxPoliceOfficers = maxPoliceOfficers;

            MrX.MrxDeleted += OnMrxDeleted;
            MrX.MrxMoved += MrXOnMrxMoved;
            PoliceOfficer.PoliceOfficerDeleted += PoliceOfficerOnPoliceOfficerDeleted;
            PoliceOfficer.PoliceOfficerMoved += PoliceOfficerOnPoliceOfficerMoved;
        }

        public int MaxPoliceOfficers { get; }
        public WinnerEnum Winner { get; private set; }
        public GameSessionId GameSessionId { get; }
        public string Name { get; }
        public DateTimeOffset StartTime { get; }
        public MrX MrX { get; private set; }
        public ICollection<PoliceOfficer> PoliceOfficers { get; }
        public Player PlayerWinning { get; private set; }
        public TimeSpan GameLength { get; } = new TimeSpan(1, 0, 0);
        public static event Action<GameSession> GameSessionCreated;
        public static event Action<MrX, GameSession> MrxAdded;
        public static event Action<PoliceOfficer, GameSession> PoliceOfficerAdded;
        public static event Action<MrX> MrXDeleted;
        public static event Action<PoliceOfficer> PoliceOfficerDeleted;
        public static event Action<Player> MrXCatched;
        public static event Action<MrX> MrXEscaped;

        public static GameSession Create(string name, int maxPoliceOfficers, out DomainValidationResult result)
        {
            var session = new GameSession(name, maxPoliceOfficers, new GameSessionId(Guid.NewGuid().ToString()));
            GameSessionCreated?.Invoke(session);
            result = DomainValidationResult.OkResult();
            return session;
        }

        private void OnMrxDeleted()
        {
            var mrxTemp = MrX;
            MrX = MrX.NullValue;
            MrXDeleted?.Invoke(mrxTemp);
        }

        private void PoliceOfficerOnPoliceOfficerMoved(PoliceOfficer policeOfficer1)
        {
            PlayerMoved();
        }

        private void PlayerMoved()
        {
            var officerCatchingMrX = PoliceOfficers
                .FirstOrDefault(officer => officer.CurrentStation.StationId == MrX.CurrentStationHidden.StationId);
            if (officerCatchingMrX == null) return;
            Winner = Police;
            PlayerWinning = officerCatchingMrX;
            MrXCatched?.Invoke(officerCatchingMrX);
        }

        private void MrXOnMrxMoved(Move move, MrX x)
        {
//            if (StartTime - DateTimeOffset.Now  > GameLength ) MrXEscaped?.Invoke(MrX);
//            else PlayerMoved();
        }

        private void PoliceOfficerOnPoliceOfficerDeleted(PoliceOfficer policeOfficer)
        {
            PoliceOfficers.Remove(policeOfficer);
            PoliceOfficerDeleted?.Invoke(policeOfficer);
        }

        public MrX AddNewMrX(string mrXName, GeoLocation playerPostLocation,
            out DomainValidationResult validationResult)
        {
            var mrX = new MrX(mrXName, playerPostLocation);
            if (MrX != MrX.NullValue)
            {
                validationResult =
                    new DomainValidationResult("Game Session can only have one MrX, delete the old one first");
                return MrX;
            }
            MrX = mrX;
            MrxAdded?.Invoke(mrX, this);
            validationResult = DomainValidationResult.OkResult();
            return mrX;
        }

        public PoliceOfficer AddNewOfficer(string officerName, GeoLocation playerPostStartLocation,
            out DomainValidationResult validationResult)
        {
            var officer = new PoliceOfficer(officerName, playerPostStartLocation);
            if (PoliceOfficers.Count == MaxPoliceOfficers)
            {
                validationResult =
                    new DomainValidationResult("Rached maxiumum of police officers");
                return officer;
            }

            PoliceOfficers.Add(officer);
            PoliceOfficerAdded?.Invoke(officer, this);
            validationResult = DomainValidationResult.OkResult();
            return officer;
        }

        public PoliceOfficer GetPoliceOfficer(PoliceOfficerId policeOfficerId,
            out DomainValidationResult validationResult)
        {
            var policeOfficer = PoliceOfficers.SingleOrDefault(officer => officer.PoliceOfficerId == policeOfficerId);
            validationResult = policeOfficer == null
                ? new DomainValidationResult("Police Officer not found")
                : DomainValidationResult.OkResult();
            return policeOfficer;
        }
    }
}