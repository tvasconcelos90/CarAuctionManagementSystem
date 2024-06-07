namespace CarAuctionManagementSystem.Models
{
    public sealed class Sedan : Vehicle
    {
        private readonly VehicleType _vehicleType = VehicleType.Sedan;

        public int NumberOfDoors { get; set; }

        public Sedan()
        {
            VehicleType = _vehicleType;
        }
    }
}
