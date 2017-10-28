using System.Threading.Tasks;
using RnvRestApi.DomainDtos;

namespace RnvRestApi.RnvAdapter
{
    public interface IRnvRepository
    {
        Task<StationDto> GetStation(StationId stationId);
        Task<StationDto> SearchStation(string stationName);
    }
}