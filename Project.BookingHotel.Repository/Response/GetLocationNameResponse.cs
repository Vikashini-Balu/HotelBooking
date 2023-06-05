using Project.BookingHotel.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Repository.Response
{
    public class GetLocationNameResponse
    {
        public List<CommonHotelLocation> commons { get; set; }
        public string ErrorMsge { get; set; }
        public bool IsFaulted { get; set; }
    }
}
