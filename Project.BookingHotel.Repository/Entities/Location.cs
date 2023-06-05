using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Project.BookingHotel.Repository.Entities;

public partial class Location
{
    public int LocationId { get; set; }

    public string? LocationName { get; set; }

    [JsonIgnore]
    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}
