using MediumHttpClient.Core.Clients;

namespace MediumHttpClient.Clients;

public class Client : IClient
{
    private readonly HttpClient _httpClient;

    public Client(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<dynamic> GetPosts()
    {
        return await _httpClient.GetFromJsonAsync<dynamic>("posts");
    }
}