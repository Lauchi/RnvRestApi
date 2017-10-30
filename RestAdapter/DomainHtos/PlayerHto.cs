﻿using Domain;

namespace RestAdapter.DomainHtos
{
    public abstract class PlayerHto
    {
        public PlayerHto(string name)
        {
            Name = name;
        }

        public PlayerHto(Player player)
        {
            Name = player.Name;
            TicketPoolId = player.Tickets.TicketPoolId.Id;
        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public int TicketPoolId { get; protected set; }
    }
}