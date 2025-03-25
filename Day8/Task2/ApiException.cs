namespace Task2
{
    public class ApiException : Exception
    {
        public ApiException() : base("Произошла ошибка при работе с API.") { }
        public ApiException(string message) : base(message) { }
        public ApiException(string message, Exception innerException) : base(message, innerException) { }
    }
}