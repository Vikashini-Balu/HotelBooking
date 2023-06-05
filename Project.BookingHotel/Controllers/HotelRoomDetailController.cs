using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Models;
using Project.BookingHotel.Service.Interface;

namespace Project.BookingHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomDetailController : ControllerBase
    {
        private readonly IHotelRoomDetailService hotelRoomDetailService;

        public HotelRoomDetailController(IHotelRoomDetailService _hotelRoomDetailService)
        {
            hotelRoomDetailService = _hotelRoomDetailService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAllHotelRoomDetails()
        {
            return Ok(await hotelRoomDetailService.GetAllHotelRoomDetails());
        }

        [HttpGet("GetByHotelId")]
        public async Task<List<HotelRoomDetailDto>> GetHotelById(int id)
        {
            var hotel = await hotelRoomDetailService.GetByHotelId(id);

            return hotel;
        }
    }
}
