namespace CarAuctionManagementSystem.Models
{
    public sealed class Truck : Vehicle
    {
        private readonly VehicleType _vehicleType = VehicleType.Truck;

        public int LoadCapacity { get; set; }
        public Truck()
        {
            VehicleType = _vehicleType;
        }
    }
}
