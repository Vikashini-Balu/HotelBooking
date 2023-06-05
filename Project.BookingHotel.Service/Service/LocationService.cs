using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Interface;
using Project.BookingHotel.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Service.Service
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository locationRepository;
        public LocationService(ILocationRepository _locationRepository)
        {
            locationRepository = _locationRepository;
        }
        public async Task<List<Location>> GetAllLocation()
        {
            return await locationRepository.GetAllLocation();
        }

        public  async Task<List<Location>> GetLocationById(int id)
        {
            var location = await this.locationRepository.GetLocationById(id);

            return location;
        }
        public async Task<List<CommonHotelLocation>> GetLocationName(string partialName)
        {
            return await locationRepository.GetLocationName(partialName);
        }
    }
}
