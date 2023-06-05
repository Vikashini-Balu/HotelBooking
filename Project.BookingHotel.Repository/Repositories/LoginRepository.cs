using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.BookingHotel.Repository.Context;
using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Repository.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private HotelBookingContext _hotelBookingContext;
        public LoginRepository(HotelBookingContext hotelBookingContext)
        {
            _hotelBookingContext = hotelBookingContext;
        }

        public async Task<string> GetUserLogin(string emailID, string userPassword)
        {
            
            var email = new SqlParameter("@EmailID", emailID);
            var password = new SqlParameter("@UserPassword", userPassword);
            string sql = "EXEC CheckLogin @EmailID, @UserPassword";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                email,
                password,
            };

            var results = _hotelBookingContext.Database.SqlQueryRaw<string>(sql, parameters.ToArray());

            string status = results.AsEnumerable().First().ToString();

            return status;

        }
    }
}

