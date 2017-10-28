using System.Collections.Generic;
using System.Threading.Tasks;
using RnvRestApi.DomainDtos;

namespace RnvRestApi.RnvAdapter.Mapper
{
    public interface IStationMapper
    {
        Task<IEnumerable<StationDto>> MapToStation(RnvResponse station);
    }
}