using Task4;
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите значение x: ");
            try
            {
                double x = double.Parse(Console.ReadLine());//преобразуем его в число типа double
            FunctionCalculator.Calculate(x);  //метод Calculate() для вычисления значения функции
        }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введите числовое значение.");
            }
        }
    }
