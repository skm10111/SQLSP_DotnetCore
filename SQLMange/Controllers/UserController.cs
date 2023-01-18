using Microsoft.AspNetCore.Mvc;
using SQLMange.DTO.User;
using SQLMange.Service.IService;

namespace SQLMange.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
           _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {
            return await _userService.GetUsers();
        }
        [HttpGet("getUser")]
        public async Task<ActionResult<UserDTO>> GetUser([FromQuery] int userId)
        {
            return await _userService.GetUser(userId);
        }
        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] UserAddDTO user)
        {
            await _userService.InsertUser(user);
            return Ok();
        }
        [HttpPatch]
        public async Task<ActionResult> UpdateUser([FromBody] UserDTO user)
        {
            await _userService.UpdateUser(user);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteUser([FromQuery] int userId)
        {
            await _userService.DeleteUser(userId);
            return Ok();
        }
    }
}
