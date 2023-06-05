using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Project.BookingHotel.Repository.Entities;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string HotelName { get; set; } = null!;

    public string HotelDescription { get; set; } = null!;

    public int? Rating { get; set; }

    public int NoOfRooms { get; set; }

    public string? Amenities { get; set; }

    public int? LocationId { get; set; }

    [JsonIgnore]
    public virtual ICollection<HotelRoomDetail> HotelRoomDetails { get; set; } = new List<HotelRoomDetail>();

    [JsonIgnore]
    public virtual Location? Location { get; set; }
}
