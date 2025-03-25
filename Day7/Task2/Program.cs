using System;

namespace DelegatesEventsTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            // обработка заказов с помощью делегатов
            Task2.ProcessOrder(123, Task2.ApproveOrder);
            Task2.ProcessOrder(456, Task2.CancelOrder);

            Console.ReadKey(); // нажатие для завершения
        }
    }
}