using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Interface;
using Project.BookingHotel.Repository.Models;
using Project.BookingHotel.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Service.Service
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository hotelRepository;
        public HotelService(IHotelRepository _hotelRepository)
        {
            hotelRepository = _hotelRepository;
        }
        public async Task<List<Hotel>> GetAllHotel()
        {
            return await hotelRepository.GetAllHotel();
        }

        public async Task<List<HotelDto>> GetDropDownData(string hotelName, string locationName)
        {
            return await hotelRepository.GetDropDownData( hotelName, locationName);
        }

        public async Task<List<CommonHotelLocation>> GetHotelName(string partialName)
        {
            return await hotelRepository.GetHotelName(partialName);
        }

    }
}
