using System.Threading.Tasks;
using RnvRestApi.DomainDtos;
using RnvRestApi.RnvAdapter.Mapper;
using RnvRestApi.RnvAdapter.RnvCommands;

namespace RnvRestApi.RnvAdapter
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
            return _stationMapper.MapToStation(rnvResponse);
        }

        public async Task<StationDto> SearchStation(string stationName)
        {
            var searchStationCommand = new SearchStationCommand(stationName);
            var rnvResponse = await _rnvClient.SendRequest(searchStationCommand);
            return _stationMapper.MapToStation(rnvResponse);
        }
    }
}