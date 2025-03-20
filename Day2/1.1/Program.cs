//С некоторого момента прошло 234 дня. Сколько полных недель прошло за этот период?
using Task1; 
public class Program
{
    public static void Main(string[] args)
    {
        TimeConverter converter = new TimeConverter(234);//экземпляр класса TimeConverter
        int weeks = converter.GetWeeks();//метод GetWeeks() для получения количества полных недель
        Console.WriteLine("Полных недель: " + weeks);
    }
}