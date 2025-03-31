using Task21; 
class Program
{
    static void Main(string[] args)
    {
        string text = "ничего я не хочу";

        ITextFormatStrategy upperCase = new UpperCaseFormat();
        ITextFormatStrategy lowerCase = new LowerCaseFormat();
        ITextFormatStrategy titleCase = new TitleCaseFormat();

        TextFormatter formatter = new TextFormatter(upperCase);
        Console.WriteLine("Верхний регистр: " + formatter.FormatText(text));

        formatter.SetFormatStrategy(lowerCase);
        Console.WriteLine("Нижний регистр: " + formatter.FormatText(text));

        formatter.SetFormatStrategy(titleCase);
        Console.WriteLine("Заглавный регистр: " + formatter.FormatText(text));

        Console.ReadKey(); 
    }
}