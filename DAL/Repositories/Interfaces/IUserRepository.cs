using DAL.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository : IRepository
    {
        void Update(User user);
        Task<User> GetUserByUserNameAsync(string username);
        Task<User> GetUserByUserIdAsync(int id);
        Task<IList<User>> GetUsersAsync();
        Task<bool> SaveAllAsync();
        Task<bool> SaveUserAsync(User user);
    }
}