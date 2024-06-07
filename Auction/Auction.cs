using CarAuctionManagementSystem.Models;

namespace CarAuctionManagementSystem.AuctionSrc
{
    public class Auction
    {
        public required Vehicle Vehicle { get; set; }
        public bool IsActive { get; set; } = false;
        public decimal Bid { get; set; }
        public decimal CurrentHighestBid { get; set; }
    }
}
