using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Models;

namespace Project.BookingHotel.Repository.Interface
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllHotel();
        Task<List<HotelDto>> GetDropDownData(string hotelName, string locationName);
        //Task<List<HotelDto>> DropDownSuggestedData(string hotelName);
        Task<List<CommonHotelLocation>> GetHotelName(string partialName);



    }
}
