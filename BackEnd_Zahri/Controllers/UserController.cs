using BackEnd_Zahri.DTO;
using BackEnd_Zahri.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_Zahri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Registration(CreateUserDTO userDto)
        {
            try
            {
                await _user.Registration(userDto);
                return Ok($"User dengan {userDto.Username} Terdaftar");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<ReadUserDTO>> Authenticate(CreateUserDTO createUserDto)
        {

            try
            {
                var user = await _user.Authenticate(createUserDto.Username, createUserDto.Password);
                if (user == null)
                    return BadRequest("Username/passwd tidak sama");
                return Ok(user);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }
    }
}
