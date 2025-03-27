using System.Collections;
using Task1;
    class Program
    {
        static void Main(string[] args)
        {
            var requestManager = new ServiceRequestManager();

            requestManager.AddRequest(new ServiceRequest("Иван", "Тип1"));
            requestManager.AddRequest(new ServiceRequest("Петр", "Тип2"));
            requestManager.AddRequest(new ServiceRequest("Дмитрий", "Тип1"));

            Console.WriteLine("Все заявки (отсортированные по дате):");
            ArrayList sortedRequests = requestManager.GetAllRequestsSortedByDate();
            foreach (ServiceRequest r in sortedRequests)
            {
                Console.WriteLine(r);
            }

            Console.WriteLine("\nЗаявки типа Тип1:");
            ArrayList requests = requestManager.FindRequestsByType("Тип1");
            foreach (ServiceRequest r in requests)
            {
                Console.WriteLine(r);
            }

            Console.WriteLine("\nОбработка заявок:");
            requestManager.ProcessNextRequest();
            requestManager.ProcessNextRequest();
            requestManager.ProcessNextRequest();
            requestManager.ProcessNextRequest(); // проверка пустой очереди

        }
    }
