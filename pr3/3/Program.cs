// Задание 3 р абота с матрицей (N x N) - ввод с клавиатуры
public class Task3
{
    public static void MatrixOperations()
    {
        Console.WriteLine("Введите размер матрицы N (N < 10):");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0 || n > 10)
        {
            Console.WriteLine("Некорректный ввод N.");
            return;
        }

        Console.WriteLine("Введите минимальное значение a:");
        if (!int.TryParse(Console.ReadLine(), out int minValue))
        {
            Console.WriteLine("Некорректный ввод a.");
            return;
        }

        Console.WriteLine("Введите максимальное значение b (b > a):");
        if (!int.TryParse(Console.ReadLine(), out int maxValue))
        {
            Console.WriteLine("Некорректный ввод b.");
            return;
        }

        if (minValue >= maxValue)
        {
            Console.WriteLine("Значение 'minValue' должно быть меньше 'maxValue'.");
            return;
        }

        Console.WriteLine("Введите порог D:");
        if (!int.TryParse(Console.ReadLine(), out int threshold))
        {
            Console.WriteLine("Некорректный ввод D.");
            return;
        }

        Random random = new Random();
        int[,] matrix = new int[n, n];

        Console.WriteLine("Исходная матрица:");  //заполнение и вывод матрицы
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue + 1);
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
        int countLessThanThreshold = 0;
        foreach (var element in matrix.Cast<int>())
        {
            if (element < threshold) countLessThanThreshold++;
        }
        Console.WriteLine($"Количество чисел, меньших {threshold}: {countLessThanThreshold}");

        Console.WriteLine("Среднее арифметическое каждого столбца:"); //заполнение и вывод матрицы
        for (int j = 0; j < n; j++)
        {
            double columnSum = 0;
            for (int i = 0; i < n; i++) columnSum += matrix[i, j];
            Console.WriteLine($"Столбец {j + 1}: {columnSum / n}");
        }
    }

    public static void Main(string[] args)
    {
        MatrixOperations(); //вызов метода без параметров
    }
}