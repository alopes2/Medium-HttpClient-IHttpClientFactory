namespace MediumHttpClient.Core.Services;

public interface IService
{
    Task<dynamic> GetPostsFromHttpClient();

    Task<dynamic> GetPostsFromNamedClient();

    Task<dynamic> GetPostsFromTypedClient();
}
