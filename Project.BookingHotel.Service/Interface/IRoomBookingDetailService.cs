using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Service.Interface
{
    public interface IRoomBookingDetailService
    {
       Task<List<RoomBookingDetail>> GetRoomBookingDetails();
       Task<List<RoomBookingDetailDto>> GetCheckInDetail(string mail);
       Task<List<RoomBookingDetailDto>> GetCheckOutDetail(string mail);
    }
}
