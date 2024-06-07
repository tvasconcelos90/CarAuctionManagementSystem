using CarAuctionManagementSystem.Models;

namespace CarAuctionManagementSystem.AuctionSrc
{
    public record AuctionInventory
    {
        public IList<Vehicle> Vehicles { get; set; } = [];
    }
}
