using System.Collections;

namespace Task1
{
    public class ServiceRequestManager
    {
        private readonly Queue _requestQueue = new Queue();

        public void AddRequest(ServiceRequest request)
        {
            _requestQueue.Enqueue(request);
            Console.WriteLine($"Заявка от {request.CustomerName} добавлена.");
        }

        public ServiceRequest ProcessNextRequest()
        {
            if (_requestQueue.Count == 0)
            {
                Console.WriteLine("Очередь пуста.");
                return null;
            }
            ServiceRequest request = (ServiceRequest)_requestQueue.Dequeue();
            Console.WriteLine($"Обработка заявки от {request.CustomerName}.");
            return request;
        }

        public ArrayList FindRequestsByType(string requestType)
        {
            ArrayList result = new ArrayList();
            foreach (var item in _requestQueue)
            {
                ServiceRequest request = (ServiceRequest)item;
                if (request.RequestType == requestType)
                {
                    result.Add(request);
                }
            }
            return result;
        }

        public void DisplayAllRequests()
        {
            foreach (var item in _requestQueue)
            {
                ServiceRequest request = (ServiceRequest)item;
                Console.WriteLine(request);
            }
        }

        public ArrayList GetAllRequestsSortedByDate()
        {
            ArrayList requests = new ArrayList(_requestQueue);
            requests.Sort(new ServiceRequestDateComparer());
            return requests;
        }
    }
}