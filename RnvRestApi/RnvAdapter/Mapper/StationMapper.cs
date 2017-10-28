using RnvRestApi.DomainDtos;

namespace RnvRestApi.RnvAdapter.Mapper
{
    public class StationMapper : IStationMapper
    {
        public StationDto MapToStation(RnvResponse station)
        {
            return new StationDto();
        }
    }
}