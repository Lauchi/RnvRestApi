using RnvRestApi.DomainDtos;

namespace RnvRestApi.RnvAdapter.Mapper
{
    public interface IStationMapper
    {
        StationDto MapToStation(RnvResponse station);
    }
}