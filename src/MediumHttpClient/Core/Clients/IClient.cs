namespace MediumHttpClient.Core.Clients;

public interface IClient
{
    Task<dynamic> GetPosts();
}
