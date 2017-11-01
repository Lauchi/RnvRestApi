using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace RnvTriasAdapter.Mapper
{
    public interface IStationMapper
    {
        Task<IEnumerable<Station>> MapToStation(RnvResponse station);
    }
}