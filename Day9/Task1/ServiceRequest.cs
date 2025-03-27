namespace Task1
{
    public class ServiceRequest
    {
        public Guid Id { get; }
        public string CustomerName { get; set; }
        public string RequestType { get; set; }
        public DateTime CreatedDate { get; }

        public ServiceRequest(string customerName, string requestType)
        {
            Id = Guid.NewGuid();
            CustomerName = customerName;
            RequestType = requestType;
            CreatedDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Customer: {CustomerName}, Type: {RequestType}, Created: {CreatedDate}";
        }
    }
}