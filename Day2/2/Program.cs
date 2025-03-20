//Проверить истинность высказывания:Данное целое число является нечетным трехзначным числом
using Task2;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите целое число: ");
        int number = int.Parse(Console.ReadLine());

        NumberChecker checker = new NumberChecker(number);//экземпляр класса NumberChecker, передавая введенное число

        if (checker.IsOddThreeDigit())
        {
            Console.WriteLine("Данное целое число является нечетным трехзначным");
        }
        else
        {
            Console.WriteLine("Данное целое число не является нечетным трехзначным");
        }
    }
}