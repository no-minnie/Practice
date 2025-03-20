namespace Task7
{
    public class PriceTable
    {
        public static void GenerateTableWhile(double pricePerItem)
        {
            Console.WriteLine("Таблица цен (while):");
            int quantity = 10;//начальное
            while (quantity <= 200)//while для генерации таблицы цен от 10 до 200 штук
            {
                Console.WriteLine($"Количество: {quantity}, Цена: {quantity * pricePerItem:F2}");
                quantity += 10;// увеличиваем на 10
            }
        }

        public static void GenerateTableDoWhile(double pricePerItem)
        {
            Console.WriteLine("\nТаблица цен (do-while):");
            int quantity = 10;
            do
            {
                Console.WriteLine($"Количество: {quantity}, Цена: {quantity * pricePerItem:F2}");
                quantity += 10;//увеличиваем количество товара на 10
            } while (quantity <= 200);//условие выполнения цикла
        }

        public static void GenerateTableFor(double pricePerItem)
        {
            Console.WriteLine("\nТаблица цен (for):");
            for (int quantity = 10; quantity <= 200; quantity += 10)
            {
                Console.WriteLine($"Количество: {quantity}, Цена: {quantity * pricePerItem:F2}");
            }
        }
    }
}