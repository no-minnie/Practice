using Task8;
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите значение A (-5 <= A <= 5): ");
            try
            {
                double a = double.Parse(Console.ReadLine());

                if (a < -5 || a > 5)
                {
                    Console.WriteLine("Ошибка: A должно быть между -5 и 5.");
                    return; 
                }

                Console.Write("Введите значение N (1 <= N <= 10): ");
                try
                {
                    int n = int.Parse(Console.ReadLine());

                    if (n < 1 || n > 10)
                    {
                        Console.WriteLine("Ошибка: N должно быть между 1 и 10.");
                        return; 
                    }

                    double result = SumCalculator.CalculateSum(a, n); //метод CalculateSum() класса SumCalculator для расчета суммы
                Console.WriteLine($"Сумма: {result}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Введите числовое значение для N.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введите числовое значение для A.");
            }
        }
    }
