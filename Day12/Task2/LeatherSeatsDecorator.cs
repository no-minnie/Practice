namespace Task2
{
    public class LeatherSeatsDecorator : CarDecorator
    {
        public LeatherSeatsDecorator(ICar car) : base(car) { }

        public override string GetFeatures()
        {
            return base.GetFeatures() + ", с кожаными сиденьями";
        }

        public override double GetPrice()
        {
            return base.GetPrice() + 120000;
        }
    }
}