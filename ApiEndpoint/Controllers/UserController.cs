using Application.Dto;
using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEndpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser user;

        public UserController(IUser user)
        {
            this.user = user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginDto loginDto)
        {
            var response = await user.LoginAsync(loginDto);
            return Ok(response);
        }

        [HttpPost("signup")]
        public async Task<ActionResult<LoginResponse>> Signup(SignupDto signupDto)
        {
            var response = await user.SignupAsync(signupDto);
            return Ok(response);
        }

        [HttpPost("logout")]
        public async Task<ActionResult<LoginResponse>> Logout()
        {
            // Clear the cookie
            Response.Cookies.Delete("jwt");
            return Ok(new LoginResponse(true, "Logged out successfully"));
        }
    }
}
