public class Permutation
{
    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Введите трехзначное число: ");
            int number = int.Parse(Console.ReadLine());

            if (number < 100 || number > 999)
            {
                Console.WriteLine("Ошибка: Введите трехзначное число.");
            }
            else
            {
                int lastDigit = number % 10;   //последняя цифра
                int remainingDigits = number / 10;  

                int newNumber = lastDigit * 100 + remainingDigits;  .

                Console.WriteLine("Полученное число: " + newNumber);
            }
        }
        catch (FormatException) 
        {
            Console.WriteLine("Ошибка: Введены некорректные данные.");
        }
    }
}