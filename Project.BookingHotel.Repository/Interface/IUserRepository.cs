using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Models;

namespace Project.BookingHotel.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUser();
        Task<List<User>> GetUserByEmailId(string id);
        Task<string> AddUser(UserDto user);
        Task<User> UpdateUser(UserDto user);

        //Task DeleteUserByEmailId(string id);

    }
}
