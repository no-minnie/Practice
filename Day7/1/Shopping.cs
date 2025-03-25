namespace DelegatesEvents
{
    public class ShoppingCart
    {
        public decimal CalculateTotalPriceWithDiscount(Item item, DiscountCalculator discountDelegate)
        {
            decimal discountedPrice = discountDelegate(item.Price);
            Console.WriteLine($"Цена товара {item.Name} со скидкой: {discountedPrice:C}");
            return discountedPrice;
        }
    }
}