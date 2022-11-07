using AutoMapper;
using BLL.ModelsDTO;
using BLL.Services.Interfaces;
using DAL.Data.Entities;
using DAL.Storage.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly BLeaderContext _context;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(BLeaderContext context,
            ITokenService tokenService,
            IMapper mapper,
            ILogger<AccountController> logger,
            IUserService userService)
        {
            _context = context;
            _tokenService = tokenService;
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("register")]

        public async Task<ActionResult<UserViewModel>> Register(RegisterViewModel viewModel)
        {
            if (await UserExists(viewModel.Username))
            {
                return BadRequest("Username is taken");
            }

            var userDto = _mapper.Map<UserDto>(viewModel);
            //var user = _mapper.Map<User>(viewModel);
            userDto.Username = viewModel.Username.ToLower();
           
            //var userDto = await _userService.GetUserAsync(viewModel.Username);
            //change to service
            //    _context.Users.Add(user);
            //await _context.SaveChangesAsync();
            var success = await _userService.SaveUserAsync(userDto);
            if (!success)
            {
                return BadRequest("Failed to register user");
            }
            var userViewModel = _mapper.Map<UserViewModel>(userDto);

            userViewModel.Token = _tokenService.CreateToken(userDto);

            return userViewModel;
        }


        [HttpPost("login")]

        public async Task<ActionResult<UserViewModel>> Login(LoginViewModel viewModel)
        {
            var userDto = await _userService.GetUserAsync(viewModel.Username);
            if (userDto == null)
            {
                return Unauthorized("Invalid user");
            }

            var userViewModel = _mapper.Map<UserViewModel>(userDto);
            //var user = await _context.Users.SingleOrDefaultAsync(x => x.Name == viewModel.Username.ToLower());


            using var hmac = new HMACSHA512(userDto.PasswordSalt);
            var givenPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(viewModel.Password));

            for (int i = 0; i < givenPasswordHash.Length; i++)
            {
                if (givenPasswordHash[i] != userDto.PasswordHash[i]) return Unauthorized("Invalid user");
            }

            userViewModel.Token = _tokenService.CreateToken(userDto);

            return userViewModel;
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.Name == username.ToLower());
        }
    }
}
