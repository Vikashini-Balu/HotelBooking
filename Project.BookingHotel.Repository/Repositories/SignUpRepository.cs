using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.BookingHotel.Repository.Context;
using Project.BookingHotel.Repository.Interface;
using Project.BookingHotel.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Repository.Repositories
{
    public class SignUpRepository : ISignUpRepository
    {
        private HotelBookingContext _hotelBookingContext;
        public SignUpRepository(HotelBookingContext hotelBookingContext)
        {
            _hotelBookingContext = hotelBookingContext;
        }

        public async Task<string> GetUserSignUp(UserDto userdto)
        {
            SqlParameter emailIdParam = new SqlParameter("@EmailID", userdto.EmailId);
            SqlParameter firstNameParam = new SqlParameter("@FirstName", userdto.FirstName);
            SqlParameter lastNameParam = new SqlParameter("@LastName", userdto.LastName);
            SqlParameter UserPasswordParam = new SqlParameter("@UserPassword", userdto.UserPassword);
            SqlParameter isAdminParam = new SqlParameter("@IsAdmin", userdto.IsAdmin);
            SqlParameter phoneNumberParam = new SqlParameter("@PhoneNumber", userdto.PhoneNumber);
            SqlParameter isActiveParam = new SqlParameter("@IsActive", userdto.IsActive);

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                emailIdParam,
                firstNameParam,
                lastNameParam,
                UserPasswordParam,
                isAdminParam,
                phoneNumberParam,
                isActiveParam,

            };

            string sql = "EXEC SignUp @EmailID,@FirstName,@LastName,@UserPassword,@IsAdmin,@PhoneNumber,@IsActive";
            var results = _hotelBookingContext.Database.SqlQueryRaw<string>(sql, parameters.ToArray());
            string status = results.AsEnumerable().First().ToString();
            return status;
        }
    }
}
