﻿using Domain;

namespace RestAdapter.DomainHtos
{
    public class StationHto
    {
        public StationHto(Station stationDto)
        {
            StationId = stationDto.StationId.Id;
            Name = stationDto.Name;
            GeoLocation = stationDto.GeoLocation;
            Type = stationDto.Type.ToString();
        }

        public string Name { get; set; }
        public string StationId { get; set; }
        public string Type { get; set; }
        public GeoLocation GeoLocation { get; set; }
    }
}