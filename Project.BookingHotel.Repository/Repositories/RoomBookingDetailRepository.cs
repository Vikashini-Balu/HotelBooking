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
    public class RoomBookingDetailRepository : IRoomBookingDetailRepository
    {
        private HotelBookingContext _hotelBookingContext;
        public RoomBookingDetailRepository(HotelBookingContext hotelBookingContext)
        {
            _hotelBookingContext = hotelBookingContext;
        }

        public async Task<List<RoomBookingDetail>> GetRoomBookingDetails()
        {
            var result = _hotelBookingContext.RoomBookingDetails.FromSqlRaw("USP_GetAllRoomBookingDetail").ToList();
            return result;
        }

        public async Task<List<RoomBookingDetailDto>> GetCheckInDetail(string mail)
        {
            DataAccessBase dab = new DataAccessBase(this._hotelBookingContext.Database.GetConnectionString());
            var dr = await dab.ExecuteReaderAsync("GetCheckInDetails", Parameters =>
            {
                Parameters.AddWithValue("@EmailID", mail);
            });
            List<RoomBookingDetailDto> list = new();
            while (await dr.ReadAsync())
            {
                RoomBookingDetailDto rb = new();
                if (Convert.ToString(dr["AccessDenied"]) != "")
                {
                    rb.AccessDenied = "Access Denied";
                    list.Add(rb);
                    break;
                }
                rb.EmailId = Convert.ToString(dr["EmailID"]);
                rb.Hrid = Convert.ToInt32(dr["HRID"]);
                rb.HotelRoomNumber = Convert.ToString(dr["HotelRoomNumber"]);
                rb.HotelId = Convert.ToInt32(dr["HotelID"]);
                rb.RoomTypeId = Convert.ToInt32(dr["RoomTypeID"]);
                rb.RoomDescription = Convert.ToString(dr["RoomDescription"]);
                rb.RoomPrice = Convert.ToInt32(dr["RoomPrice"]);
                rb.RoomBookingId = Convert.ToInt32(dr["RoomBookingId"]);
                rb.CheckInDate = Convert.ToDateTime(dr["CheckInDate"]);
                rb.CheckOutDate = Convert.ToDateTime(dr["CheckOutDate"]);
                rb.TotalAmount = Convert.ToInt32(dr["TotalAmount"]);
                rb.TotalAmount = Convert.ToInt32(dr["TotalAmount"]);
                rb.BookedDate = Convert.ToDateTime(dr["BookedDate"]);
                rb.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                rb.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);
                list.Add(rb);
            }           
            return list;
        }

        public async Task<List<RoomBookingDetailDto>> GetCheckOutDetail(string mail)
        {
            DataAccessBase dab = new DataAccessBase(this._hotelBookingContext.Database.GetConnectionString());
            var dr = await dab.ExecuteReaderAsync("GetCheckOutDetails", Parameters =>
            {
                Parameters.AddWithValue("@EmailID", mail);
            });
            List<RoomBookingDetailDto> list = new();
            while (await dr.ReadAsync())
            {
                RoomBookingDetailDto rb = new();
                if (Convert.ToString(dr["AccessDenied"]) != "")
                {
                    rb.AccessDenied = "Access Denied";
                    list.Add(rb);
                    break;
                }
                rb.EmailId = Convert.ToString(dr["EmailID"]);
                rb.Hrid = Convert.ToInt32(dr["HRID"]);
                rb.HotelRoomNumber = Convert.ToString(dr["HotelRoomNumber"]);
                rb.HotelId = Convert.ToInt32(dr["HotelID"]);
                rb.RoomTypeId = Convert.ToInt32(dr["RoomTypeID"]);
                rb.RoomDescription = Convert.ToString(dr["RoomDescription"]);
                rb.RoomPrice = Convert.ToInt32(dr["RoomPrice"]);
                rb.RoomBookingId = Convert.ToInt32(dr["RoomBookingId"]);
                rb.CheckInDate = Convert.ToDateTime(dr["CheckInDate"]);
                rb.CheckOutDate = Convert.ToDateTime(dr["CheckOutDate"]);
                rb.TotalAmount = Convert.ToInt32(dr["TotalAmount"]);
                rb.TotalAmount = Convert.ToInt32(dr["TotalAmount"]);
                rb.BookedDate = Convert.ToDateTime(dr["BookedDate"]);
                rb.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                rb.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);
                list.Add(rb);
            }
            return list;
        }
    }
}
