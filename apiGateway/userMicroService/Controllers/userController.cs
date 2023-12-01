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
        private readonly Mapper _mapper;
        private readonly IConfiguration _configuration;

        public UserController(IIdentityService identityService, IUserService userService, IConfiguration configuration, Mapper mapper)
        {
            _userService = userService;
            _identityService = identityService;
            _configuration = configuration;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("changeRole")]
        public async Task<IActionResult> ChangeUserRole(int userId, int roleId)
        {
            if(userId == 0 || roleId == 0)
            {
                return BadRequest("Une erreur s'est produite. Veuillez selectionner l'utilisateur et le role que vous voulez lui associer.");
            }
            try
            {
                int rolesClaim = Int32.Parse(User.FindFirst(ClaimTypes.Role).Value);
                if (rolesClaim == null)
                {
                    return BadRequest("Vous n'êtes pas autorisé(e).");
                }
                if(rolesClaim < 3 && rolesClaim > 0)
                {
                    User userToChange = await _userService.GetById(userId);
                    UserUpdate userUpdate = new();
                    if (userToChange == null)
                    {
                        return BadRequest("Utilisateur non trouvé.");
                    }
                    if(userToChange.RoleId == roleId)
                    {
                        return BadRequest("Cet utilisateur possède déja ce role.");
                    }
                    userToChange.RoleId = roleId;
                    _mapper.Map(userToChange, userUpdate);
                    User savedUser =  _userService.UpdateUser(userToChange);
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
                Response.Headers.Add("Set-Cookie", "Authorization=Bearer " + user.Bearer + "; Path=/; HttpOnly; Secure");
                return Ok(user);
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    };
}