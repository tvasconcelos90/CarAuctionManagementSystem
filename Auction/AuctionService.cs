using CarAuctionManagementSystem.Models;
using CarAuctionManagementSystem.AuctionSrc;
using System.Data;

namespace CarAuctionManagementSystem.AuctionSrc
{
    public class AuctionService : IAuctionService
    {
        private readonly AuctionInventory _auctionInventory;
        private readonly IList<Auction> _auctions;
        public AuctionService(AuctionInventory auctionInventory, IList<Auction> auctions)
        {
            _auctionInventory = auctionInventory;
            _auctions = auctions;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            //Verify if Id is not already in use
            if (!_auctionInventory.Vehicles.Any(x => x.Id == vehicle.Id))
            {
                vehicle.Model = vehicle.Model.ToLower();
                vehicle.Manufacturer = vehicle.Manufacturer.ToLower();
                vehicle.StartingBid = Math.Round(vehicle.StartingBid, 2);

                _auctionInventory.Vehicles.Add(vehicle);
            }
            else
            {
                throw new InvalidOperationException($"Vehicle Id: {vehicle.Id} already existis");
            }
        }

        public IEnumerable<Vehicle> SearchVehicles(SearchVehicle searchVehicle)
        {
            var vehicles = _auctionInventory.Vehicles.AsQueryable();

            if (!string.IsNullOrEmpty(searchVehicle.Manufacturer))
            {
                vehicles = vehicles.Where(x => (x.Manufacturer.Equals(searchVehicle.Manufacturer.ToLower())));
            }

            if (!string.IsNullOrEmpty(searchVehicle.Model))
            {
                vehicles = vehicles.Where(x => x.Model.Equals(searchVehicle.Model.ToLower()));
            }

            if (searchVehicle.VehicleType.HasValue)
            {
                vehicles = vehicles.Where(x => x.VehicleType.Equals(searchVehicle.VehicleType));
            }

            if (searchVehicle.Year.HasValue)
            {
                vehicles = vehicles.Where(x => x.Year.Equals(searchVehicle.Year));
            }

            return [.. vehicles];
        }

        public void StartAnAuction(Vehicle vehicle)
        {
            bool vehicleExistsInInventory = _auctionInventory.Vehicles.Any(x => x.Id == vehicle.Id);
            bool vehicleInAnotherAuction = _auctions.Any(auction => auction.Vehicle.Equals(vehicle) && auction.IsActive );

            if (vehicleInAnotherAuction)
            {
                throw new InvalidOperationException($"Vehicle Id {vehicle.Id} is already in another auction.");
            }

            if (vehicleExistsInInventory && !vehicleInAnotherAuction)
            {
                var auction = new Auction
                {
                    Vehicle = vehicle,
                    IsActive = true
                };

                _auctions.Add(auction);
            }            
        }

        public void CloseTheAuction(Vehicle vehicle)
        {
            var auction = ValidateAndReturnsActiveAuction(vehicle);

            auction.IsActive = false;
        }

        public void PlaceABid(Vehicle vehicle, decimal bid)
        {
            var auction = ValidateAndReturnsActiveAuction(vehicle);

            if (vehicle.StartingBid > bid)
            {
                throw new InvalidOperationException($"Starting bid value {vehicle.StartingBid}€ is greater than selected bid {bid}€"); 
            }

            if (auction.Bid > bid)
            {
                throw new InvalidOperationException($"Current bid value {auction.Bid}€ is greater than selected bid {bid}€");
            }

            auction.Bid = bid;
        }

        private Auction ValidateAndReturnsActiveAuction(Vehicle vehicle)
        {
            var auction = _auctions.Where(auction => auction.Vehicle.Equals(vehicle) && auction.IsActive).FirstOrDefault();

            if (auction != null)
            {
                return auction;
            }

            throw new InvalidOperationException($"There is no auction active for vehicle id {vehicle.Id}.");
        }
    }
}
 