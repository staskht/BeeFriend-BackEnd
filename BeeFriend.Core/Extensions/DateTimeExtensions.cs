
namespace BeeFriend.Core.Extensions
{
    internal static class DateTimeExtensions
    {
        public static int CalculateAge(this DateTime birthDate)
        {
            var today = DateTime.UtcNow.Date;

            int age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
