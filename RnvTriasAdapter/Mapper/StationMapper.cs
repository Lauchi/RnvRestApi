using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain;
using Domain.ValueTypes.Ids;
using SqliteAdapter.Model;

namespace RnvTriasAdapter.Mapper
{
    public class StationMapper : IStationMapper
    {
        private readonly string errorMessage = @"<Code>LOCATION_NORESULTS</Code>";
        private readonly RnvScotlandYardContext _db;

        public StationMapper(RnvScotlandYardContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<Station>> MapToStation(RnvResponse station)
        {
            var readAsByteArrayAsync = await station.Content.ReadAsByteArrayAsync();
            var encodedCondent = Encoding.UTF8.GetString(readAsByteArrayAsync);
            var xml = XDocument.Parse(encodedCondent);

            var root = xml.Descendants().SingleOrDefault(d => d.Name == "{trias}LocationInformationResponse");
            var stationList = new Collection<Station>();
            if (root == null || encodedCondent.Contains(errorMessage)) return stationList;

            var locations = root.Descendants().Where(d => d.Name == "{trias}Location" && d.Parent == root).ToList();
            foreach (var location in locations)
            {
                var stopPoint = location.Descendants().Where(d => d.Name == "{trias}StopPointName");
                var stationName = stopPoint.Descendants().SingleOrDefault(d => d.Name == "{trias}Text");
                var staionId = location.Descendants().SingleOrDefault(d => d.Name == "{trias}StopPointRef");
                var stationLongitude = location.Descendants().SingleOrDefault(d => d.Name == "{trias}Longitude");
                var stationLatitude = location.Descendants().SingleOrDefault(d => d.Name == "{trias}Latitude");

                stationList.Add(new Station(new StationId(staionId?.Value), stationName?.Value,
                    new GeoLocation(Convert.ToDouble(stationLongitude?.Value),
                        Convert.ToDouble(stationLatitude?.Value)), VehicelType.NotSetYet));
            }

            var dbStations = _db.Stations;

            foreach (var s in stationList)
            {
                var stationDb = dbStations.FirstOrDefault(s2 => s2.StationId == s.StationId.Id);
                if (stationDb != null) continue;
                s.Type = RandomType();
                var newDbSttion = new StationDb
                {
                    Name = s.Name,
                    Latitude = s.GeoLocation.Latitude,
                    Longitude = s.GeoLocation.Longitude,
                    StationId = s.StationId.Id,
                    StationType = s.Type.ToString()
                };
                _db.Stations.Add(newDbSttion);
            }

            await _db.SaveChangesAsync();

            foreach (var s in stationList)
            {
                var stationInDb = dbStations.FirstOrDefault(s2 => s2.StationId == s.StationId.Id);
                s.Type = Enum.Parse<VehicelType>(stationInDb.StationType);
            }

            return stationList;
        }

        private VehicelType RandomType()
        {
            var random = new Random();
            var randomNumber = random.Next(0, 100);

            if (randomNumber <= 10) return VehicelType.Metro;
            if (randomNumber > 10 && randomNumber < 40) return VehicelType.Bus;
            return VehicelType.Taxi;
        }
    }
}