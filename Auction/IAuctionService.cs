using CarAuctionManagementSystem.Models;

namespace CarAuctionManagementSystem.AuctionSrc
{
    public interface IAuctionService
    {
        void AddVehicle(Vehicle vehicle);
        IEnumerable<Vehicle> SearchVehicles(SearchVehicle search);
        void StartAnAuction(Vehicle vehicle);
        void PlaceABid(Vehicle vehicle, decimal bid);
        void CloseTheAuction(Vehicle vehicle);

    }
}
