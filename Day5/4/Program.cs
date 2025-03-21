using Task4;
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.Write("Введите дату рождения (ГГГГ-ММ-ДД): ");
            System.DateTime birthDate = System.DateTime.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Возраст: " + birthDate.GetAge());
        }
    }
