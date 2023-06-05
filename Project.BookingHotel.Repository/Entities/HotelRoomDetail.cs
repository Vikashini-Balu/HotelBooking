using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Project.BookingHotel.Repository.Entities;

public partial class HotelRoomDetail
{
    public int Hrid { get; set; }

    public string? HotelRoomNumber { get; set; }

    public int? HotelId { get; set; }

    public int? RoomTypeId { get; set; }

    public string RoomDescription { get; set; } = null!;

    public decimal RoomPrice { get; set; }

    [JsonIgnore]
    public virtual Hotel? Hotel { get; set; }
    [JsonIgnore]
    public virtual ICollection<RoomBookingDetail> RoomBookingDetails { get; set; } = new List<RoomBookingDetail>();
    [JsonIgnore]
    public virtual HotelRoomType? RoomType { get; set; }
}
