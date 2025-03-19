//оканчивается ли данное целое число цифрой 7.
using Task5;
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите целое число: ");
            try
            {
                int number = int.Parse(Console.ReadLine());
                bool endsWithSeven = NumberChecker.EndsWithSeven(number);//метод EndsWithSeven() класса NumberChecker, чтобы проверить, оканчивается ли число на 7

            Console.WriteLine(endsWithSeven); 
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введите целое число.");
            }
        }
    }
