using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain;
using Domain.ValueTypes.Ids;

namespace RnvTriasAdapter.Mapper
{
    public class StationMapper : IStationMapper
    {
        private string errorMessage = @"<Code>LOCATION_NORESULTS</Code>";

        public async Task<IEnumerable<Station>> MapToStation(RnvResponse station)
        {
            var readAsByteArrayAsync = await station.Content.ReadAsByteArrayAsync();
            var encodedCondent = Encoding.UTF8.GetString(readAsByteArrayAsync);
            var xml = XDocument.Parse(encodedCondent);

            var root  = xml.Descendants().SingleOrDefault(d => d.Name == "{trias}LocationInformationResponse");
            var stationList = new Collection<Station>();
            if (root == null || encodedCondent.Contains(errorMessage)) return stationList;

            var locations = root.Descendants().Where(d => d.Name == "{trias}Location" && d.Parent == root ).ToList();
            foreach (var location in locations)
            {
                var stopPoint = location.Descendants().Where(d => d.Name == "{trias}StopPointName");
                var stationName = stopPoint.Descendants().SingleOrDefault(d => d.Name == "{trias}Text");
                var staionId = location.Descendants().SingleOrDefault(d => d.Name == "{trias}StopPointRef");
                var stationLongitude = location.Descendants().SingleOrDefault(d => d.Name == "{trias}Longitude");
                var stationLatitude = location.Descendants().SingleOrDefault(d => d.Name == "{trias}Latitude");

                stationList.Add(new Station(new StationId(staionId?.Value), stationName?.Value,
                    new GeoLocation(Convert.ToDouble(stationLongitude?.Value), Convert.ToDouble(stationLatitude?.Value))));
            }

            return stationList;
        }
    }
}