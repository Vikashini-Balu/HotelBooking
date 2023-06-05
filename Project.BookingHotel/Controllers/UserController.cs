using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Models;
using Project.BookingHotel.Service.Interface;

namespace Project.BookingHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;

        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await userService.GetAllUser());
        }

        [HttpGet("GetByEmailId")]
        public async Task<List<User>> GetUserByEmailId(string id)
        {
           // if (string.IsNullOrEmpty(id))
            var user = await userService.GetUserByEmailId( id);

            if (user == null)
            {
                return new List<User>();
            }

            return user;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserDto user)
        {
            string result;
            try
            {
                result = await userService.AddUser(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok(result);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Updateuser(UserDto user)
        {
            var result = await userService.UpdateUser(user);
            return Ok(result);
        }

        //[HttpDelete("RemoveUser")]
        //public async Task<IActionResult> RemoveUser(string id)
        //{
        //    await userService.DeleteUserByEmailId(id);
        //    return Ok();
        //}

    }
}
