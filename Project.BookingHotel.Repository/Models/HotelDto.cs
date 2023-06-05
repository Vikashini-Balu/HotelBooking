using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Repository.Models
{
    public class HotelDto
    {   
        public int HotelId { get; set; }
       
        public string HotelName { get; set; } = null!;
       
        public string HotelDescription { get; set; } = null!;
        
        public int? Rating { get; set; }
      
        public int NoOfRooms { get; set; }
     
        public string? Amenities { get; set; }

        public int? LocationId { get; set; }

        public string? LocationName { get; set; }


    }
}
