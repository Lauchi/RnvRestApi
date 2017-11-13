﻿using System.ComponentModel.DataAnnotations;
using Domain;

namespace SqliteAdapter.Model
{
    public class StationDb
    {
        [Key]
        public string StationId { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}