using DAL.Data.Entities;
using DAL.Repositories.Interfaces;
using DAL.Storage.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : EFBaseRepository<User>, IUserRepository
    {
        public UserRepository(BLeaderContext context): base(context)
        {
        }

        public async Task<User> GetUserByUserIdAsync(int id)
        {
            return await Context.Users
                //.Include(p => p.Photos)
                .FindAsync(id);
                
        }

        public async Task<User> GetUserByUserNameAsync(string username)
        {
            return await Context.Users
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.Name == username.ToLower());
        }

        public async Task<IList<User>> GetUsersAsync()
        {
            return await Context.Users
                .Include(p => p.Photos)
                .ToListAsync<User>();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await Context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveUserAsync(User user)
        {
            Context.Users.Add(user);
            return await Context.SaveChangesAsync() > 0;
        }

        public void Update(User user)
        {
            Context.Entry(user).State = EntityState.Modified;
        }
    }
}
