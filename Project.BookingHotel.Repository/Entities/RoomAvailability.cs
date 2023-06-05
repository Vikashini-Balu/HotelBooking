using System;
using System.Collections.Generic;

namespace Project.BookingHotel.Repository.Entities;

public partial class RoomAvailability
{
    public int Raid { get; set; }

    public int RoomBookingId { get; set; }

    public DateTime? AvailableDate { get; set; }

    public bool? IsAvailable { get; set; }

    public virtual RoomBookingDetail? RoomBooking { get; set; }
}
