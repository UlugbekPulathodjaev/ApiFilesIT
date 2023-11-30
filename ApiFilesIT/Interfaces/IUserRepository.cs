using ApiFilesIT.DTOs;

namespace ApiFilesIT.Interfaces
{
    public interface IUserRepository
    {
        ValueTask CreateAsync(UserDto userDto);
        ValueTask<UserResponseDto> GetByIdAsync(int UserId);
        ValueTask<IEnumerable<UserResponseDto>> GetAllAsync();
    }
}
