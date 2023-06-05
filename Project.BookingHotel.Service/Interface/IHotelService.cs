using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Service.Interface
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetAllHotel();

        Task<List<HotelDto>> GetDropDownData(string hotelName, string locationName);

        Task<List<CommonHotelLocation>> GetHotelName(string partialName);
    }
}
