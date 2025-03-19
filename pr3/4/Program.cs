// Задание 4 проверка наличия свободных мест в первом ряду (Кинотеатр)
public class Task4
{
    public static void CheckFreeSeatsInFirstRow(int[,] cinema)
    {
        Console.WriteLine("Состояние кинотеатра (0 - свободно, 1 - занято):");
        for (int i = 0; i < cinema.GetLength(0); i++)
        {
            for (int j = 0; j < cinema.GetLength(1); j++)
            {
                Console.Write(cinema[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine(); //строка для разделения вывода

        bool freeSeatsInFirstRow = false;
        for (int i = 0; i < cinema.GetLength(1); i++)
        {
            if (cinema[0, i] == 0)
            {
                freeSeatsInFirstRow = true;
                break;
            }
        }

        if (freeSeatsInFirstRow)
        {
            Console.WriteLine("В первом ряду есть свободные места.");
        }
        else
        {
            Console.WriteLine("В первом ряду нет свободных мест.");
        }
    }

    public static void Main(string[] args)
    {
        int[,] cinemaExample = new int[23, 40];
        cinemaExample[0, 1] = 1;
        cinemaExample[0, 5] = 1;
        cinemaExample[0, 15] = 1;

        CheckFreeSeatsInFirstRow(cinemaExample);
    }
}