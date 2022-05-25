using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediumHttpClient.Core.Clients;
using MediumHttpClient.Core.Services;

namespace MediumHttpClient.Services;

public class Service : IService
{
    private readonly IClient _typedHttpClient;

    private readonly IHttpClientFactory _httpClientFactory;

    public Service(IClient client, IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _typedHttpClient = client;
    }

    public async Task<dynamic> GetPostsFromHttpClient()
    {
        using var httpClient = _httpClientFactory.CreateClient();
        return await httpClient.GetFromJsonAsync<dynamic>("https://jsonplaceholder.typicode.com/posts");
    }

    public async Task<dynamic> GetPostsFromNamedClient()
    {
        using var httpClient = _httpClientFactory.CreateClient("MyClient");
        return await httpClient.GetFromJsonAsync<dynamic>("posts");
    }

    public async Task<dynamic> GetPostsFromTypedClient()
    {
        return await _typedHttpClient.GetPosts();
    }
}