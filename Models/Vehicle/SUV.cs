namespace CarAuctionManagementSystem.Models
{
    public sealed class SUV : Vehicle
    {
        private readonly VehicleType _vehicleType = VehicleType.SUV;

        public int NumberOfSeats { get; set; }

        public SUV()
        {
            VehicleType = _vehicleType;
        }
    }
}
