using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.ValueTypes.Ids;

namespace RnvTriasAdapter
{
    public interface IRnvRepository
    {
        Task<Station> GetStation(StationId stationId);
        Task<IEnumerable<Station>> SearchStation(string stationName);
        Task<IEnumerable<Station>> SearchStation(GeoLocation geoLocation, int distance);
    }
}