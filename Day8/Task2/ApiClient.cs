namespace Task2
{
    public class ApiClient
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<string> SendRequest(string url)
        {
            try
            {
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode(); 
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                throw; 
            }
        }
    }
}