using Task9;
    public class Program
    {
        public static void Main(string[] args)
        {
            double a = Math.PI / 4; //начальная граница интервала
            double b = Math.PI / 2; 
            int m = 15;//количество точек табулирования

        FunctionTabulate.TabulateCotangent(a, b, m);  //метод TabulateCotangent() для табулирования функции котангенса
    }
    }
