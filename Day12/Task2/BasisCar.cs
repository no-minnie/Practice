namespace Task2
{
    public class BasicCar : ICar
    {
        public string GetFeatures()
        {
            return "Базовый автомобиль";
        }

        public double GetPrice()
        {
            return 500000; 
        }
    }
}