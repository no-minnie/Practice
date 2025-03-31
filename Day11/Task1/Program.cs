namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            UISettings settings = UISettings.Instance;

            settings.SetTheme("светлая");

            string currentTheme = settings.GetTheme();
            Console.WriteLine($"Текущая тема: {currentTheme}");

            Console.ReadKey(); 
        }
    }
}