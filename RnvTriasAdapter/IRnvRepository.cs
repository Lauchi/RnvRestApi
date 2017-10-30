using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.ValueTypes.Ids;
using RnvTriasAdapter.DomainDtos;

namespace RnvTriasAdapter
{
    public interface IRnvRepository
    {
        Task<StationDto> GetStation(StationId stationId);
        Task<IEnumerable<StationDto>> SearchStation(string stationName);
        Task<IEnumerable<StationDto>> SearchStation(GeoLocationDto geoLocation);
    }
}