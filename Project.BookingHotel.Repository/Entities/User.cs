using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Project.BookingHotel.Repository.Entities;

public partial class User
{
    public Guid UserId { get; set; }

    public string EmailId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public bool? IsAdmin { get; set; }

    public long? PhoneNumber { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? IsActive { get; set; }

    public int? AdminHotelID { get; set; }

    [JsonIgnore]
    public virtual ICollection<RoomBookingDetail> RoomBookingDetails { get; set; } = new List<RoomBookingDetail>();
}
