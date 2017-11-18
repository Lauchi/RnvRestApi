using System;
using System.Threading.Tasks;
using Domain;
using Domain.ValueTypes;
using Domain.ValueTypes.Ids;
using RnvTriasAdapter;
using SqliteAdapter.Model;

namespace SqliteAdapter.Repositories
{
    public class DbMapping : IDbMapping
    {
        public MoveDb MoveMapper(Move move)
        {
            var moveMovedToStation = move.MovedToStation;
            var stationDb = new StationDb
            {
                StationId = moveMovedToStation.StationId.Id,
                Name    = moveMovedToStation.Name,
                Latitude = moveMovedToStation.GeoLocation.Latitude,
                Longitude = moveMovedToStation.GeoLocation.Longitude
            };
            return new MoveDb
            {
                Station = stationDb,
                VehicleType = move.Type.ToString()
            };
        }

        public Move MoveMapper(MoveDb moveDb)
        {
            var moveDbStation = moveDb.Station;
            var station = new Station(new StationId(moveDbStation.StationId), moveDbStation.Name,
                new GeoLocation(moveDbStation.Longitude, moveDbStation.Latitude));
            var move = new Move(station, Enum.Parse<VehicelType>(moveDb.VehicleType));
            return move;
        }

        public StationDb StationMapper(Station station)
        {
            if (station == null) return null;
            return new StationDb
            {
                Latitude = station.GeoLocation.Latitude,
                Longitude = station.GeoLocation.Longitude,
                Name = station.Name,
                StationId = station.StationId.Id
            };
        }

        public Station StationMapper(StationDb stationDb)
        {
            if (stationDb == null) return Station.NullStation();
            return new Station(new StationId(stationDb.StationId), stationDb.Name,
                new GeoLocation(stationDb.Longitude, stationDb.Latitude));
        }
    }
}