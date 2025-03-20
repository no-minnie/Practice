using System;
using System.Linq;

public class Task5
{
    // Задание 5: Работа со ступенчатыми массивами (без проверок!)
    // Добавляет строку средних значений, демонстрируя работу со ступенчатым массивом
    public static int[][] AddAverageRow(int[][] jaggedArray)
    {
        double[] rowAverages = jaggedArray.Select(row => row.Average()).ToArray();
        // Создаем строку средних значений, длина которой на 1 больше, чем у первой строки
        int[] averageRow = rowAverages.Select(avg => (int)Math.Round(avg)).Concat(new[] { 0 }).ToArray();

        int[][] newJaggedArray = jaggedArray.Concat(new[] { averageRow }).ToArray();
        return newJaggedArray;
    }

    public static void Main(string[] args)
    {
        int[][] jaggedArrayExample = new int[][]
        {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5 }, 
            new int[] { 7, 8, 9, 10 } 
        };

        Console.WriteLine("Исходный ступенчатый массив:");
        PrintJaggedArray(jaggedArrayExample);

        int[][] newJaggedArray = AddAverageRow(jaggedArrayExample);

        Console.WriteLine("\nОбновленный ступенчатый массив:");
        PrintJaggedArray(newJaggedArray);
    }

    static void PrintJaggedArray(int[][] jaggedArray)
    {
        foreach (int[] row in jaggedArray)
        {
            Console.WriteLine(string.Join(", ", row));
        }
    }
}