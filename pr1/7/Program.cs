public class Price
{
    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Цена тетради (руб.) —> ");
            double notebookPrice = double.Parse(Console.ReadLine());

            Console.Write("Цена обложки (руб.) —> ");
            double coverPrice = double.Parse(Console.ReadLine());

            Console.Write("Количество комплектов (шт.) —> ");
            int numberOfSets = int.Parse(Console.ReadLine());

            double totalCost = (notebookPrice + coverPrice) * numberOfSets; 

            Console.WriteLine("Стоимость покупки: " + totalCost + " руб.");
        }
        catch (FormatException)  
        {
            Console.WriteLine("Ошибка: Введены некорректные данные.");
        }
    }
}