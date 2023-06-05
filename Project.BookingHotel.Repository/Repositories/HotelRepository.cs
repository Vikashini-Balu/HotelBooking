using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.BookingHotel.Repository.Context;
using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Interface;
using Project.BookingHotel.Repository.Models;
using System.Data;

namespace Project.BookingHotel.Repository.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private HotelBookingContext _hotelBookingContext;
        public HotelRepository(HotelBookingContext hotelBookingContext)
        {
            _hotelBookingContext = hotelBookingContext;
        }
        public async Task<List<Hotel>> GetAllHotel()
        {
            var result = _hotelBookingContext.Hotels.FromSqlRaw("USP_Hotel").ToList();
            return result;
        }

        public async Task<List<HotelDto>> GetDropDownData(string hotelName, string locationName)
        {

            //var hotelNameParam = new SqlParameter("@hotelName", SqlDbType.VarChar, 50) { Value = hotelName ?? (object)DBNull.Value };
            //var locationNameParam = new SqlParameter("@locationName", SqlDbType.VarChar, 15) { Value = locationName ?? (object)DBNull.Value };

            //List<SqlParameter> parameters = new List<SqlParameter>
            //{
            //    hotelNameParam,
            //    locationNameParam
            //};

            List<HotelDto> results = new List<HotelDto>();
            //if (string.IsNullOrEmpty(locationName))
            //{
            // var result = _hotelBookingContext.HotelDtos.FromSqlRaw("EXECUTE USP_HotelLocationDetails",parameters).ToList();

            //}
            if (hotelName == "null" && locationName != "null")
            {
                hotelName = string.Empty;
            }
            else if (locationName == "null" && hotelName!="null")
            {
                locationName = string.Empty;
            }
            else if(hotelName == "null" && locationName == "null")
            {
                hotelName = string.Empty;
                locationName = string.Empty;
            }
            
            var hotelNameParam = new SqlParameter("@hotelName", hotelName);
            var locationNameParam = new SqlParameter("@locationName", locationName);


             results =  _hotelBookingContext.HotelDtos.FromSqlRaw("EXECUTE USP_HotelLocationDetails @hotelName, @locationName", hotelNameParam, locationNameParam).ToList();

            return results;
            
        }

        public async Task<List<CommonHotelLocation>> GetHotelName(string partialName)
        {
            var partialNameParameter = new SqlParameter("@PartialName", partialName);
            List<CommonHotelLocation> hotel = new List<CommonHotelLocation>();

            hotel = _hotelBookingContext.commonHotelLocations.FromSqlRaw("Exec GetHotelsByPartialName @PartialName", partialNameParameter).ToList();

            return hotel;
            //string sqlQuery = "EXECUTE GetHotelsByPartialName @PartialName";
            //var test=new  SqlParameter("@PartialName", partialName);
            //List<HotelDto> hd = new List<HotelDto>();

            //hd = _hotelBookingContext.HotelDtos.FromSqlRaw(sqlQuery, partialName).ToList();



            //= _hotelBookingContext.HotelDtos.FromSqlRaw(sqlQuery, partialName);

            //return hd;
        }

        
    }
}