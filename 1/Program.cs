public class Division
{
    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Введите первое число: ");
            double num1 = double.Parse(Console.ReadLine());

            Console.Write("Введите второе число: ");
            double num2 = double.Parse(Console.ReadLine());

            if (num2 == 0)  
            {
                Console.WriteLine("Ошибка: Деление на ноль!");
            }
            else
            {
                double result = num1 / num2; 
                Console.WriteLine("Результат: {0:F3}", result); 
            }
        }
        catch (FormatException) 
        {
            Console.WriteLine("Ошибка: Введены некорректные данные.");
        }
    }
}