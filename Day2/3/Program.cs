//Дано вещественное число — цена 1 кг конфет. Вывести стоимость 0.1, 0.2, … , 1 кг Входные данные: ввести одно вещественное число A (1&lt;= A & lt;= 100).
using Task3;
public class Program
{
    public static void Main(string[] args)
    {
        double price;
        while (true)
        {
            Console.Write("Введите цену за 1 кг конфет (1 <= A <= 100): ");
            if (double.TryParse(Console.ReadLine(), out price))//преобразовать введенную строку в число типа double
            {
                if (price >= 1 && price <= 100)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка: Цена должна быть в диапазоне от 1 до 100.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: Введите числовое значение для цены.");
            }
        }

        Candy candy = new Candy(price);

        Console.WriteLine("Стоимость:");
        for (double weight = 0.1; weight <= 1.0; weight += 0.1) //для расчета и вывода стоимости конфет с шагом 0.1 
        {
            double cost = candy.CalculateCost(weight);
            Console.WriteLine(weight.ToString("F1") + " кг: " + cost.ToString("F4")); 
        }
    }
}