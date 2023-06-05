using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BookingHotel.Repository.Context;
using Project.BookingHotel.Repository.Entities;
using Project.BookingHotel.Service.Interface;

namespace Project.BookingHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService loginService;

        public LoginController(ILoginService _loginService)
        {
            loginService = _loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            var result = await loginService.GetUserLogin(login.EmailID, login.UserPassword); 
            return Ok(result);
            
        }
    }
}


