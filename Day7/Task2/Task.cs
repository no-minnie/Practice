using DelegatesEvents2;
    public class Task2
    {
        public static void ProcessOrder(int orderId, OrderProcessor processor)  // метод, который принимает делегат обработки 
    {
            Console.WriteLine($"Получен заказ с ID: {orderId}");
            processor(orderId); // вызываем делегат для обработки заказа
        }

        // методы обработки заказа
        public static void ApproveOrder(int orderId)
        {
            Console.WriteLine($"Заказ с ID: {orderId} одобрен.");
        }

        public static void CancelOrder(int orderId)
        {
            Console.WriteLine($"Заказ с ID: {orderId} отменен.");
        }
    }
