namespace CarAuctionManagementSystem.Models
{
    public class SearchVehicle
    {
        public VehicleType? VehicleType { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
    }
}
