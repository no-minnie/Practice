namespace Task10
{
    public class Remover
    {
        public static string RemoveEven(string num)//метод для удаления четных цифр 
        {
            string res = ""; 

            foreach (char c in num)//перебираем символы
            {
                if (!char.IsDigit(c)) //если символ не цифра, исключение ArgumentException
                {
                    throw new ArgumentException("Входная строка должна содержать только цифры.");
                }

                int digit = int.Parse(c.ToString());//символ в цифру

                if (digit % 2 != 0)//является ли цифра нечетной
                {
                    res += digit; 
                }
            }

            return res;
        }
    }
}