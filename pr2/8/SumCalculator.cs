namespace Task8
{
    public class SumCalculator
    {
        public static double CalculateSum(double a, int n)
        {
            double sum = 1; 
            double term = 1; //член последовательности 

            for (int i = 1; i <= n; i++)
            {
                term *= a; //вычисляем A^i, умножая предыдущий член на A
                sum += term; //добавляем A^i к сумме
            }

            return sum;
        }
    }
}