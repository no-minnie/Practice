namespace DelegatesEvents
{
    public class StudentDiscount
    {
        public decimal CalculateStudentDiscount(decimal price)  // метод, который рассчитывает скидку для студентов
        {
            return price * 0.9m; // скидка 10%
        }
    }
}