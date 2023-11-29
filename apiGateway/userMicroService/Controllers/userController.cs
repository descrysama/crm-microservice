using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using userMicroService.Data.Contract.Services;
using userMicroService.Data.Dto.Incomming;
using userMicroService.Data.Dto.Outcomming;
using userMicroService.Entities;
namespace userMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IUserService _userService;

        private readonly IConfiguration _configuration;

        public UserController(IIdentityService identityService, IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _identityService = identityService;
            _configuration = configuration;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpModel createUser)
        {
            try
            {
                User user = await _userService.Create(createUser);
                return Ok(user);
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInModel loginUser)
        {
            try
            {
                UserRead user = await _userService.SignIn(loginUser);
                Response.Headers.Add("Set-Cookie", "Authorization=Bearer " + user.Bearer + "; Path=/; HttpOnly; Secure");
                return Ok(user);
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    };
}