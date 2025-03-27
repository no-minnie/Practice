using Task3;
    class Program
    {
        static void Main(string[] args)
        {
            ILogger<object> logger = new ConsoleLogger<object>();
            LoggerManager<string> manager = new LoggerManager<string>(logger);

            manager.LogError("то-то пошло не так");
            manager.LogWarning("Осторожно");

            Console.ReadKey();
        }
    }
