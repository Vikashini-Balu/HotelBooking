using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.BookingHotel.Repository.Context;
using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Interface;
using Project.BookingHotel.Repository.Models;
using System.Data;

namespace Project.BookingHotel.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {

        private HotelBookingContext _hotelBookingContext;
        public UserRepository(HotelBookingContext hotelBookingContext)
        {
            _hotelBookingContext = hotelBookingContext;
        }

        public async Task<string> AddUser(UserDto userdto)
        {
            
            SqlParameter emailIdParam = new SqlParameter("@EmailID", userdto.EmailId);
            SqlParameter firstNameParam = new SqlParameter("@FirstName", userdto.FirstName);
            SqlParameter lastNameParam = new SqlParameter("@LastName", userdto.LastName);
            SqlParameter UserPasswordParam = new SqlParameter("@UserPassword", userdto.UserPassword);
            SqlParameter isAdminParam = new SqlParameter("@IsAdmin", userdto.IsAdmin);
            SqlParameter phoneNumberParam = new SqlParameter("@PhoneNumber", userdto.PhoneNumber);
            SqlParameter isActiveParam = new SqlParameter("@IsActive", userdto.IsActive);
            SqlParameter adminHotelIDParam = new SqlParameter("@AdminHotelID", userdto.AdminHotelID);
            
            
            
            // add all the parameters to a list
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                emailIdParam,      
                firstNameParam,
                lastNameParam,
                UserPasswordParam,
                isAdminParam,
                phoneNumberParam,
                isActiveParam,
                adminHotelIDParam
               
            };

            string sql = "EXEC InsertUpdateUser @EmailID,@FirstName,@LastName,@UserPassword,@IsAdmin,@PhoneNumber,@IsActive, @AdminHotelID";

            // execute the stored procedure and retrieve the results
            var results = _hotelBookingContext.Database.SqlQueryRaw<string>(sql,parameters.ToArray());

            // retrieve the output parameter values
            string status = results.AsEnumerable().First().ToString();

            return status;
        }

        private static User GetUserDto(UserDto userDto)
        {
            var user = new User()
            {
                EmailId = userDto.EmailId,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                CreatedDate = userDto.CreatedDate,
                IsAdmin = userDto.IsAdmin,
                ModifiedDate = userDto.ModifiedDate,
                PhoneNumber = userDto.PhoneNumber,
                UserId = userDto.UserId,
            };

            return user;
        }
       

        //public async Task DeleteUserByEmailId(string id)
        //{
        //    var result = await GetUserByEmailId(id);
        //    _hotelBookingContext.Users.Remove(result);
        //    await _hotelBookingContext.SaveChangesAsync();

        //}

        public async Task<List<User>> GetAllUser()
        {
            var result = _hotelBookingContext.Users.FromSqlRaw("sp_User").ToList();
            return result;
        }

        public async Task<List<User>> GetUserByEmailId(string id)
        {
            var result = new SqlParameter("@EmailID", id);
            string sql = "EXEC sp_GetByEmailId @EmailID";
            var user = await _hotelBookingContext.Users.FromSqlRaw(sql,result).ToListAsync();
            return user;
        }
        
        public async Task<User> UpdateUser(UserDto userdto)
        {
            var user = GetUserDto(userdto);
            _hotelBookingContext.Entry(user).State = EntityState.Modified;
            await _hotelBookingContext.SaveChangesAsync();
            return user;
        }

        
    }
}