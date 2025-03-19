namespace Task3
{
    public class Candy
    {
        private double pricePerKg;

        public Candy(double pricePerKg)
        {
            this.pricePerKg = pricePerKg;
        }

        public double CalculateCost(double weight)
        {
            return pricePerKg * weight;
        }
    }
}