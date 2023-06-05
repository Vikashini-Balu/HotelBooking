using Project.BookingHotel.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Service.Interface
{
    public interface ISignUpService
    {
        Task<string> GetUserSignUp(UserDto user);
    }
}
