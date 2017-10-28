using RnvRestApi.DomainDtos;

namespace RnvRestApi.rnvAdapter
{
    public class StationMapper : IStationMapper
    {
        public StationDto MapToStation(RnvResponse station)
        {
            return new StationDto();
        }
    }
}