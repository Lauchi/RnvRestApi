using RnvRestApi.DomainDtos;

namespace RnvRestApi.RnvAdapter.RnvCommands
{
    public class GetStationCommand : RnvCommand
    {
        private readonly StationId _stationId;

        public GetStationCommand(StationId stationId)
        {
            _stationId = stationId;
        }

        public override string GetXmlRepresentation()
        {
            return "je";
        }
    }
}