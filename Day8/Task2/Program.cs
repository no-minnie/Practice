using Task2;
    public class Program
    {
        public static async Task Main(string[] args)
        {
            RequestHandler handler = new RequestHandler();

            try
            {
                string result = await handler.HandleRequest("https://fjeujfjfe");
                Console.WriteLine($"Результат: {result}");
            }
            catch (ApiException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}, Inner Exception: {ex.InnerException?.Message}");
            }

            Console.ReadKey();
        }
    }
