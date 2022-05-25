using MediumHttpClient.Clients;
using MediumHttpClient.Core.Clients;
using MediumHttpClient.Core.Services;
using MediumHttpClient.Services;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add IHttpClientFactory to the container.
builder.Services.AddHttpClient();

// Register the named client MyClient.
builder.Services.AddHttpClient("MyClient", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

    httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");

    httpClient.Timeout = TimeSpan.FromMinutes(1);
});

// Register the typed client.
builder.Services.AddHttpClient<IClient, Client>(httpClient =>
{
    httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
    
    httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");

    httpClient.Timeout = TimeSpan.FromMinutes(1);
});

builder.Services.AddTransient<IService, Service>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/http-client", (IService service) =>
    {
        return service.GetPostsFromHttpClient();
    })
    .WithName("GetPostsFromHttpClient");

app.MapGet("/named-client", (IService service) =>
    {
        return service.GetPostsFromNamedClient();
    })
    .WithName("GetPostsFromNamedClient");

app.MapGet("/typed-client", (IService service) =>
    {
        return service.GetPostsFromTypedClient();
    })
    .WithName("GetPostsFromTypedClient");

app.Run();