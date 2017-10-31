﻿using System.Collections.Generic;
using Domain;
using Domain.Validation;
using Domain.ValueTypes.Ids;

namespace EventStoring
{
    public interface IEventStore
    {
        IEnumerable<GameSession> GetSessions();
        GameSession GetSession(GameSessionId gameSessionId, out DomainValidationResult validationResult);
        MrX GetMrX(GameSessionId gameSessionId, out DomainValidationResult validationResult);
        IEnumerable<PoliceOfficer> GetPoliceOfficers(GameSessionId gameSessionId, out DomainValidationResult validationResult);
    }
}