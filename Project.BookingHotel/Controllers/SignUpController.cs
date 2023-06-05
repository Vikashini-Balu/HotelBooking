using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Repository.Models;
using Project.BookingHotel.Service.Interface;

namespace Project.BookingHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ISignUpService signupService;

        public SignUpController(ISignUpService _signupService)
        {
            signupService = _signupService;
        }

        [HttpPost]
        public async Task<IActionResult> signUp(UserDto user)
        {
            string result;
            try
            {
                result = await signupService.GetUserSignUp(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);

        }
    }
    
}
