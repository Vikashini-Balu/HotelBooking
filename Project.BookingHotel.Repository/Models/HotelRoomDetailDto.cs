using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Repository.Models
{
    public class HotelRoomDetailDto
    {
        public int Hrid { get; set; }

        public string? HotelName { get; set; }

        public string? HotelRoomNumber { get; set; }

        public int? HotelId { get; set; }

        public int? RoomTypeId { get; set; }

        public string RoomDescription { get; set; } = null!;

        public decimal RoomPrice { get; set; }
    }
}
