using BLL.Extenstions;
using System;
using System.Collections.Generic;

namespace BLL.ModelsDTO
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public IList<PhotoDto> Photos { get; set; }
        public string KnownAs { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;


        //move to helper ??
        public int GetAge()
        {
            return DateOfBirth.CalculateAge();
        }
    }
}
