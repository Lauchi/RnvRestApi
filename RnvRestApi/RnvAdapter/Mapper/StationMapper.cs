using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RnvRestApi.DomainDtos;

namespace RnvRestApi.RnvAdapter.Mapper
{
    public class StationMapper : IStationMapper
    {
        public async Task<StationDto> MapToStation(RnvResponse station)
        {
            var readAsByteArrayAsync = await station.Content.ReadAsByteArrayAsync();
            var encodedCondent = Encoding.UTF8.GetString(readAsByteArrayAsync);
            var xml = XDocument.Parse(encodedCondent);

            var locationInformation  = xml.Descendants().Where(d => d.Name == "{trias}LocationInformationResponse").ToList();
            var stopPointName = locationInformation.Descendants().Where(d => d.Name == "{trias}StopPointName");
            var stationName = stopPointName.Descendants().SingleOrDefault(d => d.Name == "{trias}Text");
            var staionId = locationInformation.Descendants().SingleOrDefault(d => d.Name == "{trias}StopPointRef");
            var stationLongitude = locationInformation.Descendants().SingleOrDefault(d => d.Name == "{trias}Longitude");
            var stationLatitude = locationInformation.Descendants().SingleOrDefault(d => d.Name == "{trias}Latitude");

            return new StationDto(new StationId(staionId?.Value), stationName?.Value,
                new GeoLocation(Convert.ToDouble(stationLongitude?.Value), Convert.ToDouble(stationLatitude?.Value)));
        }
    }
}