namespace Task3
{
    public interface ILogger<T>
    {
        void Log(T message);
    }
}