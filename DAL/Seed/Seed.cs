

using DAL.Data.Entities;
using DAL.Storage.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL.Seed
{
    public class Seed
    {
        public static async Task SeedUsers(BLeaderContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var usersData = await File.ReadAllTextAsync("../DAL/Seed/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<User>>(usersData);

            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();

                user.Name = user.Name.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("123"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }
    }
}
