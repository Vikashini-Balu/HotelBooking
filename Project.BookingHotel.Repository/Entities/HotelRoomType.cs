using System;
using System.Collections.Generic;

namespace Project.BookingHotel.Repository.Entities;

public partial class HotelRoomType
{
    public int Rtid { get; set; }

    public string RoomType { get; set; } = null!;

    public int NoOfPersons { get; set; }

    public virtual ICollection<HotelRoomDetail> HotelRoomDetails { get; set; } = new List<HotelRoomDetail>();
}
