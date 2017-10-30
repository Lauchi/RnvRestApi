namespace Domain.ValueTypes.Ids
{
    public class DomainId
    {
        public DomainId(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}