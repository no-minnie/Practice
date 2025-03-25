using System;

namespace DelegatesEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentDiscount = new StudentDiscount();  // объекты скидок
            var seniorDiscount = new SeniorDiscount();

            var cart = new ShoppingCart(); // созд корзину и товары
            var book = new Item { Name = "Книга", Price = 100m };
            var tea = new Item { Name = "Чай", Price = 50m };

            cart.CalculateTotalPriceWithDiscount(book, studentDiscount.CalculateStudentDiscount); // рассчет скидки 
            cart.CalculateTotalPriceWithDiscount(tea, seniorDiscount.CalculateSeniorDiscount);

            Console.ReadKey();
        }
    }
}