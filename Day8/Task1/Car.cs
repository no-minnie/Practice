namespace Task1
{
    public class Car
    {
        private const int MaxSpeed = 120;

        public void SetSpeed(int speed) // метод для установки скорости автомобиля
        {
            if (speed > MaxSpeed)
            {
                throw new SpeedLimitExceededException($"Скорость {speed} км/ч превышает допустимую {MaxSpeed} км/ч!");
            }

            Console.WriteLine($"Скорость установлена: {speed} км/ч");
        }
    }
}