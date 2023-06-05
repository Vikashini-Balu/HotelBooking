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
    public class RoomBookingDetailService : IRoomBookingDetailService
    {
        private readonly IRoomBookingDetailRepository roomBookingDetailRepository;
        public RoomBookingDetailService(IRoomBookingDetailRepository _roomBookingDetailRepository)
        {
            roomBookingDetailRepository = _roomBookingDetailRepository;
        }
        public async Task<List<RoomBookingDetail>> GetRoomBookingDetails()
        {
            return await roomBookingDetailRepository.GetRoomBookingDetails();
        }

        public async Task<List<RoomBookingDetailDto>> GetCheckInDetail(string mail)
        {
            return await roomBookingDetailRepository.GetCheckInDetail(mail);
        }

        public async Task<List<RoomBookingDetailDto>> GetCheckOutDetail(string mail)
        {
            return await roomBookingDetailRepository.GetCheckOutDetail(mail);
        }
    }
}
