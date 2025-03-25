namespace Task1
{
    public class SpeedLimitExceededException : Exception //  исключение для  превышения скорости
    {
        public SpeedLimitExceededException() : base("Превышена допустимая скорость!") { }

        public SpeedLimitExceededException(string message) : base(message) { }

        public SpeedLimitExceededException(string message, Exception innerException) : base(message, innerException) { }  // конструктор с сообщением и внутренним исключением
    }
}