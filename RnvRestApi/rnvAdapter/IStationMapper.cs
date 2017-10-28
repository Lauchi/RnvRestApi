using RnvRestApi.DomainDtos;

namespace RnvRestApi.rnvAdapter
{
    public interface IStationMapper
    {
        StationDto MapToStation(RnvResponse station);
    }
}