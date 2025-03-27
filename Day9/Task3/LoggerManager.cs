namespace Task3
{
    public class LoggerManager<T>
    {
        private readonly ILogger<object> _logger;

        public LoggerManager(ILogger<object> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger), "Logger cannot be null.");
        }

        public void LogError(T message)
        {
            _logger.Log($"Error: {message?.ToString()}");
        }

        public void LogWarning(T message)
        {
            _logger.Log($"Warning: {message?.ToString()}");
        }

        public void LogInformation(T message)
        {
            _logger.Log($"Info: {message?.ToString()}");
        }
    }
}