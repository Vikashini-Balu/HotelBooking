using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Request;
using Project.BookingHotel.Repository.Response;
using Project.BookingHotel.Service.Interface;

namespace Project.BookingHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService locationService;

        public LocationController(ILocationService _locationService)
        {
            locationService = _locationService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAllLocation()
        {
            return Ok(await locationService.GetAllLocation());
        }

        [HttpGet("GetByLocationId")]
        public async Task<List<Location>> GetLocationById(int id)
        {
            var location = await locationService.GetLocationById(id);

            if (location == null)
            {
                return new List<Location>();
            }
            return location;
        }

        [HttpPost("GetLocationName")]
        public async Task<GetLocationNameResponse> GetHotelName(GetLocationNameRequest request)
        {
            GetLocationNameResponse response = new();
            response.IsFaulted = true;
            try
            {
                response.commons = await locationService.GetLocationName(request.Name);
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