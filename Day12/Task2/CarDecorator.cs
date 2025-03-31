namespace Task2
{
    public abstract class CarDecorator : ICar
    {
        protected ICar _car;

        public CarDecorator(ICar car)
        {
            _car = car ?? throw new ArgumentNullException(nameof(car), "Автомобиль не может быть null.");
        }

        public virtual string GetFeatures()
        {
            return _car.GetFeatures();
        }

        public virtual double GetPrice()
        {
            return _car.GetPrice();
        }
    }
}