namespace Task2
{
    public class NavigationDecorator : CarDecorator
    {
        public NavigationDecorator(ICar car) : base(car) { }

        public override string GetFeatures()
        {
            return base.GetFeatures() + ", с навигационной системой";
        }

        public override double GetPrice()
        {
            return base.GetPrice() + 80000;
        }
    }
}