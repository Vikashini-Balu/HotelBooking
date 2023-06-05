using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Interface;
using Project.BookingHotel.Repository.Models;
using Project.BookingHotel.Service.Interface;

namespace Project.BookingHotel.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        public Task<string> AddUser(UserDto user)
        {
            var result = userRepository.AddUser(user);
            return result;
        }

        //public async Task DeleteUserByEmailId(string id)
        //{
        //    await userRepository.DeleteUserByEmailId(id);
        //}

        public async Task<List<User>> GetAllUser()
        {
            return await userRepository.GetAllUser();
        }

        public async Task<List<User>> GetUserByEmailId(string id)
        {
            var user = await this.userRepository.GetUserByEmailId(id);

            return user;
        }

        public async Task<User> UpdateUser(UserDto user)
        {
            return await userRepository.UpdateUser(user);
        }
    }
}