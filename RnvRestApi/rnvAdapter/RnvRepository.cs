using System.Threading.Tasks;
using RnvRestApi.DomainDtos;

namespace RnvRestApi.rnvAdapter
{
    public class RnvRepository
    {
        private readonly RnvClient _rnvClient;
        private readonly StationMapper _stationMapper;

        public RnvRepository(RnvClient rnvClient, StationMapper stationMapper)
        {
            _rnvClient = rnvClient;
            _stationMapper = stationMapper;
        }

        public async Task<StationDto> getStation(StationId stationId)
        {
            _rnvClient.RnvCommand = new GetStationCommand(stationId);
            var rnvResponse = await _rnvClient.SendRequest();
            return _stationMapper.MapToStation(rnvResponse);
        }

        public async Task<StationDto> searchStation(string stationName)
        {
            _rnvClient.RnvCommand = new SearchStationCommand(stationName);
            var rnvResponse = await _rnvClient.SendRequest();
            return _stationMapper.MapToStation(rnvResponse);
        }
    }
}