using Task1;
    public class Program
    {
        public static void Main(string[] args)
        {
            Car myCar = new Car();

            try
            {
                myCar.SetSpeed(100); 
                myCar.SetSpeed(150); 
            }
            catch (SpeedLimitExceededException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
