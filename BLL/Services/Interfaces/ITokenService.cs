using BLL.ModelsDTO;

namespace BLL.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(UserDto user);
    }
}
