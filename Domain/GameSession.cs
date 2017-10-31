﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using Domain.Validation;
using Domain.ValueTypes.Ids;

namespace Domain
{
    public class GameSession
    {
        public static event Action<GameSession> GameSessionCreated;
        public static event Action<GameSession> MrxAdded;
        public static event Action<GameSession> PoliceOfficerAdded;

        public static GameSession Create(string name, out DomainValidationResult result)
        {
            var session = new GameSession(name, new GameSessionId(Guid.NewGuid().ToString()));
            GameSessionCreated?.Invoke(session);
            result = DomainValidationResult.OkResult();
            return session;
        }

        private GameSession(string name, GameSessionId id)
        {
            Name = name;
            GameSessionId = id;
            PoliceOfficers = new ImmutableArray<PoliceOfficer>();
            StartTime = DateTimeOffset.Now;
            MrX = null;
        }

        public GameSession(string name, GameSessionId id, DateTimeOffset startTime, MrX mrX, ICollection<PoliceOfficer> policeOfficers)
        {
            Name = name;
            GameSessionId = id;
            StartTime = startTime;
            MrX = mrX;
            PoliceOfficers = policeOfficers;
        }

        public MrX AddNewMrX(string mrXName, out DomainValidationResult validationResult)
        {
            var mrX = new MrX(mrXName);
            if (MrX != null) {
                validationResult = new DomainValidationResult(new List<ValidationError>()
                {
                    new ValidationError("Game Session can only have one MrX, delete the old one first")
                });
                return MrX;
            }
            MrX = mrX;
            MrxAdded?.Invoke(this);
            validationResult = DomainValidationResult.OkResult();
            return mrX;
        }

        public PoliceOfficer AddNewOfficer(string officerName, out DomainValidationResult validationResult)
        {
            var officer = new PoliceOfficer(officerName);
            PoliceOfficers.Add(officer);
            PoliceOfficerAdded?.Invoke(this);
            validationResult = DomainValidationResult.OkResult();
            return officer;
        }

        public GameSessionId GameSessionId { get; }
        public string Name { get;  }
        public DateTimeOffset StartTime { get; }
        public MrX MrX { get; private set; }
        public ICollection<PoliceOfficer> PoliceOfficers { get; }
    }
}