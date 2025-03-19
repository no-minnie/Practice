public class Function
{
    public static void Main(string[] args)
    {
        double x = 0.5;

        try
        {
            double y;

            if (1 - Math.PI * Math.Abs(x) >= 0) // под корнем
            {
                y = x * Math.Exp(x * x) - (Math.Sin(Math.Sqrt(x)) + Math.Pow(Math.Cos(Math.Log(x)), 2)) / Math.Sqrt(1 - Math.Abs(Math.PI * x)); // вычисление 
                Console.WriteLine("Значение функции: " + y);
            }
            else
            {
                Console.WriteLine("Под корнем отрицательное значение, посчитать невозможно");
            }
        }
        catch (ArgumentException) // лог от отриц, нуля
        {
            Console.WriteLine("Ошибка: Логарифм от отрицательного числа или нуля.");
        }
    }
}