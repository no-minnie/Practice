public class TwoFormulas
{
    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Введите значение alpha (в радианах): ");
            double alpha = double.Parse(Console.ReadLine());

            double z1 = (Math.Cos(alpha) + Math.Sin(alpha)) / (Math.Cos(alpha) - Math.Sin(alpha));  // первая формула
            double z2 = Math.Tan(2 * alpha) + 1 / Math.Cos(2 * alpha);  // вторая 

            Console.WriteLine("z1 = " + z1);
            Console.WriteLine("z2 = " + z2);
        }
        catch (FormatException) 
        {
            Console.WriteLine("Ошибка: Введены некорректные данные.");
        }
    }
}