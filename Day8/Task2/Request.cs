namespace Task2
{
    public class RequestHandler
    {
        private readonly ApiClient _apiClient = new ApiClient();

        public async Task<string> HandleRequest(string url)
        {
            try
            {
                return await _apiClient.SendRequest(url);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ошибка при отправке запроса: {ex.Message}\n{ex.StackTrace}");

                throw new ApiException("Ошибка при обработке запроса к API.", ex);
            }
        }
    }
}