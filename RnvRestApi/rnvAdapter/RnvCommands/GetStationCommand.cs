using RnvRestApi.DomainDtos;

namespace RnvRestApi.rnvAdapter
{
    public class GetStationCommand : IRnvCommand
    {
        private readonly StationId _stationId;

        public GetStationCommand(StationId stationId)
        {
            _stationId = stationId;
        }

        public string GetXmlRepresentation()
        {
            return "je";
        }
    }
}