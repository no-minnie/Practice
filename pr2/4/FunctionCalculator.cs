namespace Task4
{
    public class FunctionCalculator
    {
        public static void Calculate(double x) //метод для вычисления и вывода значения функции
        {
            try
            {
                Console.WriteLine(Math.Log10(2 * x) + Math.Sqrt(1 + x * x));
            }
            catch (Exception)
            {
                Console.WriteLine("Произошла ошибка.");
            }
        }
    }
}