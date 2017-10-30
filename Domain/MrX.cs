﻿using System;
using Domain.ValueTypes.Ids;

namespace Domain
{
    public class MrX : Player
    {
        public MrX(MrXId mrXId, string name) : base(name)
        {
            MrXId = mrXId;
        }

        public MrXId MrXId { get; private set; }

        public static MrX NullValue()
        {
            return new MrX("NAN")
            {
                MrXId = new MrXId("NAN")
            };
        }

        public MrX(string name) : base(name)
        {
            MrXId = new MrXId(Guid.NewGuid().ToString());
        }
    }
}