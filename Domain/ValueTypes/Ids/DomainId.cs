namespace Domain.ValueTypes.Ids
{
    public class DomainId
    {
        public DomainId(string id)
        {
            Id = id;
        }
        public string Id { get; }
    }
}