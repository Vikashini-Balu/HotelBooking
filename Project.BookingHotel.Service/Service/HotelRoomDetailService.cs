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
    public class HotelRoomDetailService : IHotelRoomDetailService
    {
        private readonly IHotelRoomDetailRepository hotelRoomDetailRepository;
        public HotelRoomDetailService(IHotelRoomDetailRepository _hotelRoomDetailRepository)
        {
            hotelRoomDetailRepository = _hotelRoomDetailRepository;
        }

        public async Task<List<HotelRoomDetail>> GetAllHotelRoomDetails()
        {
            return await hotelRoomDetailRepository.GetAllHotelRoomDetails();
        }

        public async Task<List<HotelRoomDetailDto>> GetByHotelId(int id)
        {
            var hotelRoomDetail = await this.hotelRoomDetailRepository.GetByHotelId(id);

            return hotelRoomDetail;
        }
    }
}
