using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BookingHotel.Repository.Models
{
    public class UserDto
    {
        public Guid UserId { get; set; }

        public string EmailId { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string UserPassword { get; set; }

        public bool? IsAdmin { get; set; }

        public Int64 PhoneNumber { get; set; }
         
        public bool IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? AdminHotelID { get; set; }
    }
}
