using System.Text.RegularExpressions;
namespace Packt.CS6
{
    public static class StringExtensions
    {
        public static bool IsValidEmail(this string input)
        {
            // используйте простое регулярное выражение для
            // проверки, что строка содержит допустимый email
            return Regex.IsMatch(input, @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
        }
    }
}