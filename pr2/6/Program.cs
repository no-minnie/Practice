using Task6;
public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите пол (м - мужской, ж - женский): ");
        string gender = Console.ReadLine();

        try
        {
            List<string> names = Name.GetNames(gender);

            Console.WriteLine("Имена:");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}