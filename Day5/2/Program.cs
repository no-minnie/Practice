using Task2;
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 123, -45, 6789, 0, 555 };

            foreach (int number in numbers)
            {
                try
                {
                    DigitCounter.CountSum(number, out int count, out int sum);
                    Console.WriteLine("Число: " + number + ", Количество цифр: " + count + ", Сумма цифр: " + sum);
                }
                catch (System.ArgumentException ex)
                {
                    Console.WriteLine("Число: " + number + ", Ошибка: " + ex.Message);
                }
            }
        }
    }