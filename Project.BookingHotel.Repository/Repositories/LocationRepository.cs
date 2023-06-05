using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.BookingHotel.Repository.Context;
using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Repository.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private HotelBookingContext _hotelBookingContext;
        public LocationRepository(HotelBookingContext hotelBookingContext)
        {
            _hotelBookingContext = hotelBookingContext;
        }
        public async Task<List<Location>> GetAllLocation()
        {
            var result = _hotelBookingContext.Locations.FromSqlRaw("sp_GetAllLocation").ToList();
            return result;
        }

        public async Task<List<Location>> GetLocationById(int id)
        {
            var result = new SqlParameter("@LocationID", id);
            string sql = "EXEC sp_GetByLocationId @LocationID";
            var user = await _hotelBookingContext.Locations.FromSqlRaw(sql, result).ToListAsync();
            return user;
        }

        public async Task<List<CommonHotelLocation>> GetLocationName(string partialName)
        {
            var partialNameParameter = new SqlParameter("@LocationPartialName", partialName);
            List<CommonHotelLocation> location = new List<CommonHotelLocation>();

            location = _hotelBookingContext.commonHotelLocations.FromSqlRaw("Exec GetLocationsByPartialName @LocationPartialName", partialNameParameter).ToList();

            return location;
        }
    }
}