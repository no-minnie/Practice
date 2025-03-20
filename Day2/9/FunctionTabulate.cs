namespace Task9
{
    public class FunctionTabulate
    {
        public static void TabulateCotangent(double a, double b, int m)
        {
            double h = (b - a) / m;//вычисляем шаг табулирования

            Console.WriteLine("Значения Ctg(x):");
            for (int i = 0; i <= m; i++)
            {
                double x = a + i * h;//вычисляем текущее значение аргумента x
                double cotangent = 1.0 / Math.Tan(x);//вычисляем значение котангенса
                Console.WriteLine($"Ctg({x:F6}) = {cotangent:F6}");
            }
        }
    }
}