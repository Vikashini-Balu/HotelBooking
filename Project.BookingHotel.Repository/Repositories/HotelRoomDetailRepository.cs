using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.BookingHotel.Repository.Context;
using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Interface;
using Project.BookingHotel.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Repository.Repositories
{
    public class HotelRoomDetailRepository : IHotelRoomDetailRepository
    {
        private HotelBookingContext _hotelBookingContext;
        public HotelRoomDetailRepository(HotelBookingContext hotelBookingContext)
        {
            _hotelBookingContext = hotelBookingContext;
        }

        public async Task<List<HotelRoomDetail>> GetAllHotelRoomDetails()
        {
            var result = _hotelBookingContext.HotelRoomDetails.FromSqlRaw("USP_GetAllHotelRoomDetail").ToList();
            return result;
        }

        public async Task<List<HotelRoomDetailDto>> GetByHotelId(int id)
        {
            var result = new SqlParameter("@HotelID", id);
            string sql = "EXEC USP_GetHotelRoomDetailsByHotelID @HotelID";
            var hotel = await _hotelBookingContext.hotelRoomDetailDtos.FromSqlRaw(sql, result).ToListAsync();
            return hotel;
        }
    }
}
