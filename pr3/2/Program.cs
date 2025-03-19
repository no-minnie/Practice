// Задание 2 посчитать сумму положительных, число отрицательных и нулевых членов последовательности.
public class Task2
{
    public static void CountPositiveNegativeZero(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            Console.WriteLine("Массив пуст или не существует.");
            return;
        }

        int positiveCount = 0;
        int negativeCount = 0;
        int zeroCount = 0;
        int positiveSum = 0;

        foreach (int num in array)
        {
            if (num > 0)
            {
                positiveCount++;
                positiveSum += num;
            }
            else if (num < 0)
            {
                negativeCount++;
            }
            else
            {
                zeroCount++;
            }
        }

        Console.WriteLine($"Сумма положительных: {positiveSum}, Количество отрицательных: {negativeCount}, Количество нулей: {zeroCount}");
    }

    public static void Main(string[] args)
    {
        int[] exampleArray = { 5, 2, 8, -1, 0, 10 };
        CountPositiveNegativeZero(exampleArray);
    }
}