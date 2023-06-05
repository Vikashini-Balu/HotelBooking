using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BookingHotel.Repository.Models;
using Project.BookingHotel.Repository.Request;
using Project.BookingHotel.Repository.Response;
using Project.BookingHotel.Service.Interface;

namespace Project.BookingHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService hotelService;

        public HotelController(IHotelService _hotelService)
        {
            hotelService = _hotelService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAllHotel()
        {
            return Ok(await hotelService.GetAllHotel());
        }

        [HttpPost("DropDownData")]

        public async Task<IActionResult> GetDropDownData(HotelDto Hotel)
        {

            var hotel = await hotelService.GetDropDownData(Hotel.HotelName, Hotel.LocationName);

            return Ok(hotel);

        }

        //[HttpPost("DropDownSuggestedData")]

        //public async Task<IActionResult> GetDropDownData(HotelDto Hotel)
        //{

        //    var hotel = await hotelService.GetDropDownData(Hotel.HotelName, Hotel.LocationName);

        //    return Ok(hotel);

        //}

        [HttpPost("GetHotelName")]

        public async Task<GetHotelNameResponse> GetHotelName(GetHotelNameRequest request)
        {
            GetHotelNameResponse response = new();
            response.IsFaulted = true;
            try
            {
                //throw new NotImplementedException();
                response.commons = await hotelService.GetHotelName(request.Name);
                response.IsFaulted = false;
            }
            catch (Exception ex)
            {
                response.ErrorMsge = "Something Went Wrong...";
            }
            return response;
        }
    }
}
