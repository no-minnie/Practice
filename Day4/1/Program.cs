/*Метод нахождения среднего арифметического a и b, метод вычисления
значения выражения b^3+sqrt(a) .*/
public class A
{
    private int a;
    private int b;
    public A(int a, int b)// конструктор 
    {
        this.a = a;
        this.b = b;
    }

    public double Average()// метод для среднего арифметического
    {
        return (double)(a + b) / 2;
    }

    public double CalculateExpression() // метод для b^3 + sqrt(a)
    {
        return Math.Pow(b, 3) + Math.Sqrt(a);
    }

    public void PrintValues() // метод для вывода значений
    {
        Console.WriteLine($"a = {a}, b = {b}");
    }

    public static void Main(string[] args)
    {
        A myObject = new A(5, 2); // создание объекта
        myObject.PrintValues();
        Console.WriteLine($"Среднее арифметическое: {myObject.Average()}");
        Console.WriteLine($"Результат выражения: {myObject.CalculateExpression()}");
    }
}