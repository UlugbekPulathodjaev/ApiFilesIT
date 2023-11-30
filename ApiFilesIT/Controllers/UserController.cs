using ApiFilesIT.DTOs;
using ApiFilesIT.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiFilesIT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostAsync([FromForm] UserDto userModel)
        {
            await _userRepository.CreateAsync(userModel);
            return Ok("Created");
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int Id)
        {
            UserResponseDto user = await _userRepository.GetByIdAsync(Id);

            return Ok(new
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
            });
        }

        [HttpGet]
        public async ValueTask<FileContentResult> GetImageByUserIdAsync(int UserId)
        {
            UserResponseDto user = await _userRepository.GetByIdAsync(UserId);

            return File(user.imageBytes, "image/png");
        }
    }
}
