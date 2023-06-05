using Project.BookingHotel.Repository.Interface;
using Project.BookingHotel.Repository.Models;
using Project.BookingHotel.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Service.Service
{
    public class SignUpService : ISignUpService
    {
        private readonly ISignUpRepository signupRepository;
        public SignUpService(ISignUpRepository _signupRepository)
        {
            signupRepository = _signupRepository;
        }

        public Task<string> GetUserSignUp(UserDto user)
        {
            var result = signupRepository.GetUserSignUp(user);
            return result;
        }
    }
}
