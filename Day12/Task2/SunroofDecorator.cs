namespace Task2
{
    public class SunroofDecorator : CarDecorator
    {
        public SunroofDecorator(ICar car) : base(car) { }

        public override string GetFeatures()
        {
            return base.GetFeatures() + ", с люком";
        }

        public override double GetPrice()
        {
            return base.GetPrice() + 50000;
        }
    }
}