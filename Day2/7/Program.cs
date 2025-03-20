//таблицу стоимости для 10, 20, 30,…, 200 штук товара, при условии, что одна штука товара стоит х руб (значение х водится с клавиатуры);
using Task7;
   public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Введите цену за единицу товара: ");
            try
            {
                double pricePerItem = double.Parse(Console.ReadLine());
            //методы для генерации таблицы цен с использованием разных циклов
                PriceTable.GenerateTableWhile(pricePerItem);
                PriceTable.GenerateTableDoWhile(pricePerItem);
                PriceTable.GenerateTableFor(pricePerItem);
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введите числовое значение для цены.");
            }
        }
    }
