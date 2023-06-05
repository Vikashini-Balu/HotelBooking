﻿using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Service.Interface
{
    public interface IHotelRoomDetailService
    {
        Task<List<HotelRoomDetail>> GetAllHotelRoomDetails();
        Task<List<HotelRoomDetailDto>> GetByHotelId(int id);
    }
}
