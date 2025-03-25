using Task3;
    class Program
    {
        static void Main(string[] args)
        {
            EmailValidator validator = new EmailValidator();

            Console.WriteLine("Введите email-адрес для проверки:");
            string email = Console.ReadLine();

            try
            {
                validator.ValidateEmail(email);
                Console.WriteLine("Email-адрес корректен.");
            }
            catch (InvalidEmailException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
