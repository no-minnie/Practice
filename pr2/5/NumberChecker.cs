namespace Task5
{
    public class NumberChecker
    {
        public static bool EndsWithSeven(int number) //метод для проверки, оканчивается ли число на 7
        {
            return number % 10 == 7;//true, если остаток от деления числа на 10 равен 7
        }
    }
}