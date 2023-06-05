using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Project.BookingHotel.Repository.Entities;

public partial class RoomBookingDetail
{
    public int RoomBookingId { get; set; }

    public string? EmailId { get; set; }

    public DateTime? CheckInDate { get; set; }

    public DateTime? CheckOutDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public DateTime? BookedDate { get; set; }

    public int? Hrid { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string ModifiedBy { get; set; } = null!;

    public int? StatusID { get; set; }

    [JsonIgnore]
    public virtual User? Email { get; set; }
   
    [JsonIgnore]
    public virtual HotelRoomDetail? Hr { get; set; }

    [JsonIgnore]
    public virtual ICollection<RoomAvailability> RoomAvailabilities { get; set; } = new List<RoomAvailability>();
}
