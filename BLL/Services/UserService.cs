using AutoMapper;
using BLL.ModelsDTO;
using BLL.Services.Interfaces;
using DAL.Data.Entities;
using DAL.Repositories.Interfaces;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserAsync(string username)
        {
            var user = await _userRepository.GetUserByUserNameAsync(username);

            return  _mapper.Map<UserDto>(user);
        }

        public async Task<bool> SaveUserAsync(UserDto userDto)
        {
            using var hmac = new HMACSHA512();
            userDto.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password));
            userDto.PasswordSalt = hmac.Key;
            var user = _mapper.Map<User>(userDto);

            return await _userRepository.SaveUserAsync(user);
        }
    }
}
