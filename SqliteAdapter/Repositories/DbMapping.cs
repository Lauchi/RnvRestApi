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
        private IRnvRepository _rnvRepository;

        public DbMapping(IRnvRepository rnvRepository)
        {
            _rnvRepository = rnvRepository;
        }

        //move to interface
        public MoveDb MoveMapper(Move move)
        {
            var moveMovedToStation = move.MovedToStation;
            return new MoveDb
            {
                StationId = moveMovedToStation.StationId.Id,
                VehicleType = move.Type.ToString()
            };
        }

        public async Task<Move> MoveMapper(MoveDb moveDb)
        {
            var station = await _rnvRepository.GetStation(new StationId(moveDb.StationId));
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