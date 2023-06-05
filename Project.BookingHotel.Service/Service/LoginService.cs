using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Interface;
using Project.BookingHotel.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Service.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository loginRepository;
        public LoginService(ILoginRepository _loginRepository)
        {
            loginRepository = _loginRepository;
        }

        public async Task<string> GetUserLogin(string emailID, string userPassword)
        {
            return await loginRepository.GetUserLogin(emailID, userPassword);
        }
    }
}
