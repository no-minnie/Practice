namespace DelegatesEvents
{
    public class SeniorDiscount
    {
        public decimal CalculateSeniorDiscount(decimal price) // метод, который рассчитывает скидку для пенсионеров
        {
            return price * 0.8m; // скидка 20%
        }
    }
}