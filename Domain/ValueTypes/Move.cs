namespace Domain.ValueTypes
{
    public class Move
    {
        public Move(Station movedToStation, VehicelType type)
        {
            MovedToStation = movedToStation;
            Type = type;
        }
        
        public Station MovedToStation { get; }
        public VehicelType Type { get; }
    }
}