//9 Заменить все вхождения одного слова другим
public class Task9
{
    public static string ReplaceWord(string text, string oldWord, string newWord)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(oldWord))
        {
            return text; // если пусто, то исходный 
        }

        return text.Replace(oldWord, newWord); // метод Replace для замены 
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите исходный текст:");
        string inputText = Console.ReadLine(); // исходный текст с консоли

        Console.WriteLine("Введите слово, которое нужно заменить:");
        string oldWord = Console.ReadLine(); // слово, которое нужно заменить

        Console.WriteLine("Введите слово, на которое нужно заменить:");
        string newWord = Console.ReadLine(); // слово, на которое нужно заменить

        string replacedText = ReplaceWord(inputText, oldWord, newWord); // вызываем метод ReplaceWord для выполнения замены

        Console.WriteLine($"Результат: {replacedText}"); 
    }
}