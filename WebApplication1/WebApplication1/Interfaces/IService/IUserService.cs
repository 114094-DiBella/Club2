using WebApplication1.Dtos;
using WebApplication1.Response;

namespace WebApplication1.Interfaces.IService
{
    public interface IUserService
    {
        public Task<ApiResponse<UserDtoResponseTokenDto>> ValidateUser(UserDto user);
    }
}
