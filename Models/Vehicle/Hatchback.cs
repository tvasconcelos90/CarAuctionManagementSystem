namespace CarAuctionManagementSystem.Models
{
    public sealed class Hatchback : Vehicle
    {
        private readonly VehicleType _vehicleType = VehicleType.Hatchback;

        public int NumberOfDoors { get; set; }
        public Hatchback()
        {
            VehicleType = _vehicleType;
        }
    }
}
