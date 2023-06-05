using Project.BookingHotel.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Service.Interface
{
    public interface ILocationService
    {
        Task<List<Location>> GetAllLocation();
        Task<List<Location>> GetLocationById(int id);
        Task<List<CommonHotelLocation>> GetLocationName(string partialName);
    }
}
