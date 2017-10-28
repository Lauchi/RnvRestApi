using System.Collections.Generic;
using System.Threading.Tasks;
using RnvRestApi.DomainDtos;

namespace RnvRestApi.RnvAdapter
{
    public interface IRnvRepository
    {
        Task<StationDto> GetStation(StationId stationId);
        Task<IEnumerable<StationDto>> SearchStation(string stationName);
    }
}