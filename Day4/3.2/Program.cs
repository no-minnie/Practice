//Создайте систему управления товарами на складе
public abstract class Product //aбстрактный класс родительский
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public abstract string GetProductType();
}

public sealed class Electronics : Product // запечатанный класс
{
    public override string GetProductType()
    {
        return "Электроника";
    }
}

public sealed class Clothing : Product
{
    public override string GetProductType()
    {
        return "Одежда";
    }
}

public class Warehouse // модельный класс с массивом 
{
    private List<Product> products = new List<Product>();

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public List<Product> GetProducts()
    {
        return products;
    }

    public decimal GetTotalStockValue() // метод б-л вычисление общей стоимости товаров
    {
        return products.Sum(p => p.Price * p.Quantity);
    }

    public Product FindMostExpensiveProduct() // метод б-л найти самый дорогой продукт
    {
        return products.OrderByDescending(p => p.Price).FirstOrDefault();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Warehouse warehouse = new Warehouse();

        Electronics tv = new Electronics { Name = "Телевизор", Price = 500, Quantity = 10 };
        Clothing shirt = new Clothing { Name = "Рубашка", Price = 25, Quantity = 100 };

        warehouse.AddProduct(tv); // добавление на склад
        warehouse.AddProduct(shirt);

        Console.WriteLine($"Общая стоимость запасов: {warehouse.GetTotalStockValue()}");

        Product mostExpensive = warehouse.FindMostExpensiveProduct();
        Console.WriteLine($"Самый дорогой продукт: {mostExpensive.Name}");
    }
}