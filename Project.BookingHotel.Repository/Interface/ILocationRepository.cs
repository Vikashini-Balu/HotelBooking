using Project.BookingHotel.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Repository.Interface
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetAllLocation();
        Task<List<Location>> GetLocationById(int id);
        Task<List<CommonHotelLocation>> GetLocationName(string partialName);
    }
}
