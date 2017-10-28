using System.Threading.Tasks;
using RnvRestApi.DomainDtos;

namespace RnvRestApi.RnvAdapter.Mapper
{
    public interface IStationMapper
    {
        Task<StationDto> MapToStation(RnvResponse station);
    }
}