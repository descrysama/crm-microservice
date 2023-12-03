using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserController(IIdentityService identityService, IUserService userService, IConfiguration configuration, IMapper mapper)
        {
            _userService = userService;
            _identityService = identityService;
            _configuration = configuration;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("updateuseradmin")]
        public async Task<IActionResult> UpdateUserAdmin(UserUpdate user)
        {
            try
            {
                int rolesClaim = Int32.Parse(User.FindFirst(ClaimTypes.Role).Value);
                int adminId = Int32.Parse(User.FindFirst(ClaimTypes.Sid).Value);
                if (rolesClaim == null)
                {
                    return BadRequest("Vous n'êtes pas autorisé(e).");
                }
                if(adminId == user.Id)
                {
                    return BadRequest("Vous ne pouvez pas modifier votre profile ici. Rendez vous dans votre espace personnel.");
                }
                if(rolesClaim > user.RoleId)
                {
                    return BadRequest("Vous ne pouvez pas appliquer ce role");
                }
                if(rolesClaim < 2 && rolesClaim > 0)
                {
                    User userToChange = await _userService.GetById(user.Id);
                    if (userToChange == null)
                    {
                        return BadRequest("Utilisateur non trouvé.");
                    }
                    User updatedUser = _mapper.Map(user, userToChange);
                    User savedUser = _userService.UpdateUser(updatedUser);
                    return Ok(savedUser);

                } else
                {
                    return BadRequest("Vous n'êtes pas autorisé(e).");
                }

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
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
                string BearerToken = _identityService.GenerateToken(user);
                user.Bearer = BearerToken;
                Response.Headers.Add("Set-Cookie", "Authorization=Bearer " + user.Bearer + "; Path=/; HttpOnly; Secure");
                return Ok(user);
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    };
}