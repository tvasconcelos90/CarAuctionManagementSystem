namespace CarAuctionManagementSystem.Models
{
    public abstract class Vehicle
    {
        public int Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal StartingBid { get; set; }

    }
}
