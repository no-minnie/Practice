public class Resistors
{
   public static void Main(string[] args)
    {
        try
        {
            Console.Write("Введите значение R1: ");
            double r1 = double.Parse(Console.ReadLine());

            Console.Write("Введите значение R2: ");
            double r2 = double.Parse(Console.ReadLine());

            Console.Write("Введите значение R3: ");
            double r3 = double.Parse(Console.ReadLine());

            double reciprocalResistance = (1 / r1) + (1 / r2) + (1 / r3);  //обратное 
            double totalResistance = 1 / reciprocalResistance;   //общее

            Console.WriteLine("Общее сопротивление: " + totalResistance);
        }
        catch (FormatException) 
        {
            Console.WriteLine("Ошибка: Введены некорректные данные.");
        }
        catch (DivideByZeroException) 
        {
            Console.WriteLine("Ошибка: Одно из сопротивлений равно нулю.");
        }
    }
}