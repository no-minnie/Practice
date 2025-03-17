public class Transposition
{
    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Введите двузначное число: ");
            int number = int.Parse(Console.ReadLine());

            if (number < 10 || number > 99)
            {
                Console.WriteLine("Ошибка: Введите двузначное число.");
            }
            else
            {
                int tens = number / 10;    //десятки
                int ones = number % 10;    //единицы

                int newNumber = ones * 10 + tens;  

                Console.WriteLine("Полученное число: " + newNumber);
            }
        }
        catch (FormatException) 
        {
            Console.WriteLine("Ошибка: Введены некорректные данные.");
        }
    }
}