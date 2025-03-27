namespace Task3
{
    public class ConsoleLogger<T> : ILogger<T>
    {
        public void Log(T message)
        {
            Console.WriteLine(message?.ToString());
        }
    }
}