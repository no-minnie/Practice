namespace Task3
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException() : base("Некорректный формат email-адреса.") { }
        public InvalidEmailException(string message) : base(message) { }
        public InvalidEmailException(string message, Exception innerException) : base(message, innerException) { }
    }
}