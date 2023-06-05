using Project.BookingHotel.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Service.Interface
{
    public interface ILoginService
    {
        Task <string> GetUserLogin(string emailID, string userPassword);
    }
}
