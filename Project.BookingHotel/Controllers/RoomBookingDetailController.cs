using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BookingHotel.Repository.Models;
using Project.BookingHotel.Service.Interface;

namespace Project.BookingHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomBookingDetailController : ControllerBase
    {
        private readonly IRoomBookingDetailService roomBookingDetailService;

        public RoomBookingDetailController(IRoomBookingDetailService _roomBookingDetailService)
        {
            roomBookingDetailService = _roomBookingDetailService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAllRoomBookingDetails()
        {
            return Ok(await roomBookingDetailService.GetRoomBookingDetails());
        }

        [HttpPost("GetCheckInDetails")]
        public async Task<List<RoomBookingDetailDto>> GetCheckIndetail(RoomBookingDetailDto roomBookingDetail)
        {
            var user = await roomBookingDetailService.GetCheckInDetail(roomBookingDetail.EmailId);

            if (user == null)
            {
                return new List<RoomBookingDetailDto>();
            }
            return user;
        }

        [HttpPost("GetCheckOutDetails")]
        public async Task<List<RoomBookingDetailDto>> GetCheckOutdetail(RoomBookingDetailDto roomBookingDetail)
        {
            var user = await roomBookingDetailService.GetCheckOutDetail(roomBookingDetail.EmailId);

            if (user == null)
            {
                return new List<RoomBookingDetailDto>();
            }
            return user;
        }

    }
}
