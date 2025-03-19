//8 Реализовать метод шифрования строки методом Цезаря 
public class Task8
{
    public static string CaesarCipher(string text, int key)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text; // если пусто, то выводим исходник
        }

        string result = "";
        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                char offset;
                int alphabetLength;

                // определение алфавита и смещение 
                if (c >= 'а' && c <= 'я') 
                {
                    offset = 'а';
                    alphabetLength = 32; 
                }
                else if (c >= 'А' && c <= 'Я') 
                {
                    offset = 'А';
                    alphabetLength = 32;
                }
                else if (c >= 'a' && c <= 'z') 
                {
                    offset = 'a';
                    alphabetLength = 26;
                }
                else if (c >= 'A' && c <= 'Z') 
                {
                    offset = 'A';
                    alphabetLength = 26;
                }
                else
                {
                    result += c; 
                    continue;
                }
                char shiftedChar = (char)(((c + key - offset) % alphabetLength) + offset); // шифруем, сдвигом на key

                result += shiftedChar;
            }
            else
            {
                result += c;
            }
        }
        return result;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Введите строку для шифрования:");
        string inputText = Console.ReadLine();

        Console.WriteLine("Введите ключ (сдвиг):");
        if (!int.TryParse(Console.ReadLine(), out int key))
        {
            Console.WriteLine("Некорректный ключ. Используется ключ по умолчанию (3).");
            key = 3; 
        }

        string encryptedText = CaesarCipher(inputText, key);

        Console.WriteLine($"Зашифрованная строка: {encryptedText}");
    }
}