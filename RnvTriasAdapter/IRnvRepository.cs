using System.Collections.Generic;
using System.Threading.Tasks;
using RnvTriasAdapter.DomainDtos;
using StationId = RnvTriasAdapter.DomainDtos.StationId;

namespace RnvTriasAdapter
{
    public interface IRnvRepository
    {
        Task<StationDto> GetStation(StationId stationId);
        Task<IEnumerable<StationDto>> SearchStation(string stationName);
    }
}