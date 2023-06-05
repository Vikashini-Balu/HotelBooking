using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Repository.Models
{
    public class RoomBookingDetailDto
    {
        public string? EmailId { get; set; }

        public int? Hrid { get; set; }

        public string? HotelRoomNumber { get; set; }

        public int? HotelId { get; set; }

        public int? RoomTypeId { get; set; }

        public string? RoomDescription { get; set; } = null!;

        public decimal? RoomPrice { get; set; }

        public int? RoomBookingId { get; set; }
       
        public DateTime? CheckInDate { get; set; }

        public DateTime? CheckOutDate { get; set; }

        public decimal? TotalAmount { get; set; }

        public DateTime? BookedDate { get; set; }

        public string? CreatedBy { get; set; } = null!;

        public string? ModifiedBy { get; set; } = null!;

        public string AccessDenied { get; set; }

        
    }
}
