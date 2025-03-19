using Task10;
public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите число: ");
        string num = Console.ReadLine();

        try
        {
            string result = Remover.RemoveEven(num);
            Console.WriteLine($"Число без четных цифр: {result}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}"); 
        }
    }
}