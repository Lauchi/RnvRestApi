using Domain;

namespace RestAdapter.DomainHtos
{
    public abstract class PlayerHto
    {
        public PlayerHto(Player player)
        {
            Name = player.Name;
        }

        public string Id { get; protected set; }
        public string Name { get; protected set; }
    }
}