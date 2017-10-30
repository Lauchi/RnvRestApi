using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ValueTypes.Ids;
using RnvTriasAdapter.DomainDtos;
using RnvTriasAdapter.Mapper;
using RnvTriasAdapter.RnvCommands;

namespace RnvTriasAdapter
{
    public class RnvRepository : IRnvRepository
    {
        private readonly RnvClient _rnvClient;
        private readonly IStationMapper _stationMapper;

        public RnvRepository(RnvClient rnvClient, IStationMapper stationMapper)
        {
            _rnvClient = rnvClient;
            _stationMapper = stationMapper;
        }

        public async Task<StationDto> GetStation(StationId stationId)
        {
            var getStationCommand = new GetStationCommand(stationId);
            var rnvResponse = await _rnvClient.SendRequest(getStationCommand);
            var stationDtos = await _stationMapper.MapToStation(rnvResponse);
            return stationDtos.SingleOrDefault();
        }

        public async Task<IEnumerable<StationDto>> SearchStation(string stationName)
        {
            var searchStationCommand = new SearchStationCommand(stationName);
            var rnvResponse = await _rnvClient.SendRequest(searchStationCommand);
            return await _stationMapper.MapToStation(rnvResponse);
        }

        public async Task<IEnumerable<StationDto>> SearchStation(GeoLocationDto geoLocation)
        {
            var searchStationCommand = new SearchStationByLocationCommand(geoLocation);
            var rnvResponse = await _rnvClient.SendRequest(searchStationCommand);
            return await _stationMapper.MapToStation(rnvResponse);
        }
    }
}