using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Interfaces.IService;
using WebApplication1.Response;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
            
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ApiResponse<UserDtoResponseTokenDto>> Post([FromBody] UserDto value)
        {

            return await _userService.ValidateUser(value);
        }
    }
}
