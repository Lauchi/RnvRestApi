namespace RnvRestApi.Domain.ValueTypes.Ids
{
    public class StationId
    {
        public StationId(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}