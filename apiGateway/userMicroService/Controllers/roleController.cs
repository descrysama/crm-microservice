using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using userMicroService.Data.Contract.Services;
namespace userMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        public RoleController()
        {
        }
    };
}