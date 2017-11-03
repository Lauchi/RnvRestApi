using System.Collections.Generic;
using Domain;

namespace StationAsJsonAdapter
{
    public class StationNode
    {
        public Station Station { get; }
        public ICollection<VehicelType> AvailableVehicles { get; }
        public ICollection<StationNode> NextNodes { get; }
    }
}