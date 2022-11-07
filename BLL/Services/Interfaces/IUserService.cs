using BLL.ModelsDTO;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(string username);
        Task<bool> SaveUserAsync(UserDto userDto);
    }
}
