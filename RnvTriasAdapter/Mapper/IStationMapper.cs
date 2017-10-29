using System.Collections.Generic;
using System.Threading.Tasks;
using RnvTriasAdapter.DomainDtos;

namespace RnvTriasAdapter.Mapper
{
    public interface IStationMapper
    {
        Task<IEnumerable<StationDto>> MapToStation(RnvResponse station);
    }
}