using System.Text.RegularExpressions;
namespace Task3
{
    public class EmailValidator
    {
        public void ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new InvalidEmailException("Email-адрес не может быть пустым.");
            }

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(email))
            {
                throw new InvalidEmailException("Email-адрес имеет некорректный формат.");
            }
        }
    }
}