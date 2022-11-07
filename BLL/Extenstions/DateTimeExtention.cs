using System;

namespace BLL.Extenstions
{
    public static class DateTimeExtention
    {
        public static int CalculateAge(this DateTime dateOfBirth)
        {
            var today = DateTime.Now;
            var age = today.Year - dateOfBirth.Year;
            if(dateOfBirth.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
