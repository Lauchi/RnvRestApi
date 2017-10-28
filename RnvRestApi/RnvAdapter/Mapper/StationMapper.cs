using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using RnvRestApi.Domain;
using RnvRestApi.Domain.ValueTypes;
using RnvRestApi.Domain.ValueTypes.Ids;
using RnvRestApi.DomainDtos;

namespace RnvRestApi.RnvAdapter.Mapper
{
    public class StationMapper : IStationMapper
    {
        public async Task<IEnumerable<StationDto>> MapToStation(RnvResponse station)
        {
            var readAsByteArrayAsync = await station.Content.ReadAsByteArrayAsync();
            var encodedCondent = Encoding.UTF8.GetString(readAsByteArrayAsync);
            var xml = XDocument.Parse(encodedCondent);

            var root  = xml.Descendants().SingleOrDefault(d => d.Name == "{trias}LocationInformationResponse");
            var stationList = new Collection<StationDto>();
            if (root == null) return stationList;

            var locations = root.Descendants().Where(d => d.Name == "{trias}Location" && d.Parent == root ).ToList();
            foreach (var location in locations)
            {
                var stopPoint = location.Descendants().Where(d => d.Name == "{trias}StopPointName");
                var stationName = stopPoint.Descendants().SingleOrDefault(d => d.Name == "{trias}Text");
                var staionId = location.Descendants().SingleOrDefault(d => d.Name == "{trias}StopPointRef");
                var stationLongitude = location.Descendants().SingleOrDefault(d => d.Name == "{trias}Longitude");
                var stationLatitude = location.Descendants().SingleOrDefault(d => d.Name == "{trias}Latitude");

                stationList.Add(new StationDto(new StationId(staionId?.Value), stationName?.Value,
                    new GeoLocation(Convert.ToDouble(stationLongitude?.Value), Convert.ToDouble(stationLatitude?.Value))));
            }

            return stationList;
        }
    }
}