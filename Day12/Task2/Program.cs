using Task2;

class Program
{
    static void Main(string[] args)
    {
        ICar myCar = new BasicCar();

        Console.WriteLine("Выберите опции для автомобиля (введите номера через запятую):");
        Console.WriteLine("1: Люк");
        Console.WriteLine("2: Навигационная система");
        Console.WriteLine("3: Кожаные сиденья");
        Console.WriteLine("0: Ничего не добавлять");

        string input = Console.ReadLine();
        string[] options = input.Split(',');

        foreach (string option in options)
        {
            switch (option.Trim())
            {
                case "1":
                    myCar = new SunroofDecorator(myCar);
                    break;
                case "2":
                    myCar = new NavigationDecorator(myCar);
                    break;
                case "3":
                    myCar = new LeatherSeatsDecorator(myCar);
                    break;
                case "0":
                    break; 
                default:
                    Console.WriteLine($"Неизвестная опция: {option}");
                    break;
            }
        }

        Console.WriteLine("\nВаш автомобиль: " + myCar.GetFeatures());
        Console.WriteLine("Цена: " + myCar.GetPrice());

        Console.ReadKey();
    }
}