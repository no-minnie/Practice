// 7 Преобразовать строку в верхний и нижний регистр
public class Task7
{  
    public static void ConvertCase(string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            Console.WriteLine("Строка пуста или не существует.");
            return;
        }

        string upperCase = str.ToUpper(); // строку в верхний регистр
        string lowerCase = str.ToLower(); // в нижний 

        Console.WriteLine($"Верхний регистр: {upperCase}");
        Console.WriteLine($"Нижний регистр: {lowerCase}");
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите строку:");
        string inputString = Console.ReadLine();

        ConvertCase(inputString);
    }
}