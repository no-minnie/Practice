// Задание 1 найти минимальный элемент массива и его порядковый номер.

public class Task1
{
    public static void FindMinElement(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            Console.WriteLine("Массив пуст или не существует.");
            return;
        }

        Console.WriteLine("Исходный массив: " + string.Join(", ", array)); //dывод исходного массива

        int min = array[0];
        int minIndex = 0;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
                minIndex = i;
            }
        }

        Console.WriteLine($"Минимальный элемент: {min}, Индекс: {minIndex}");
    }

    public static void Main(string[] args)
    {
        int[] exampleArray = { 5, 2, 8, -1, 0, 10 };
        FindMinElement(exampleArray);
    }
}