namespace Task2
{
    public class NumberChecker
    {
        private int number;

        public NumberChecker(int number)
        {
            this.number = number;
        }

        public bool IsOdd()//метод для проверки, является ли число нечетным
        {
            return (number % 2 != 0); //true, если остаток от деления на 2 не равен 0
        }

        public bool IsThreeDigit()//метод для проверки, является ли число трехзначным
        {
            return (number >= 100 && number <= 999);//true, если число больше или равно 100 и меньше или равно 999
        }

        public bool IsOddThreeDigit() // для проверки, является ли число нечетным и трехзначным
        {
            return IsOdd() && IsThreeDigit();
        }
    }
}