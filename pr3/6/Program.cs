public class Task6
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine();

        if (CanFormPalindrome(input))
        {
            Console.WriteLine("Можно сделать палиндром!");
        }
        else
        {
            Console.WriteLine("Нельзя сделать палиндром.");
        }
    }

    public static bool CanFormPalindrome(string s)
    {
        Dictionary<char, int> charCounts = new Dictionary<char, int>();

        foreach (char c in s)
        {
            if (char.IsLetterOrDigit(c)) 
            {
                if (charCounts.ContainsKey(c))
                {
                    charCounts[c]++;
                }
                else
                {
                    charCounts[c] = 1;
                }
            }
        }

        int oddCount = 0; //подсчитываем символы с нечетным количеством
        foreach (var count in charCounts.Values)
        {
            if (count % 2 != 0)
            {
                oddCount++;
            }
        }

        return oddCount <= 1; //если нечетных символов больше 1, то нельзя
    }
}
