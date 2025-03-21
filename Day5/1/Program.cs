using Task1;
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите целое число: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int decimalNumber))
            {
                string binaryRepresentation = BinaryConvert.ConvertToBinary(decimalNumber);
                Console.WriteLine("Десятичное число: " + decimalNumber + ", Двоичное представление: " + binaryRepresentation);
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
            }
        }
    }
