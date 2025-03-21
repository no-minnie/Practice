using Task3;
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string inputString = System.Console.ReadLine();
            string reversedString = StringReverse.ReverseString(inputString);
            Console.WriteLine("Перевернутая строка: " + reversedString);
        }
    }
