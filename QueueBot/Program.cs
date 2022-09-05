using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QueueBot.Services;

var hostBuilder = Host.CreateDefaultBuilder(args);
hostBuilder.ConfigureServices(
    services =>
    {
        services.AddHostedService<BotService>();
        services.AddSingleton<HttpClient>();
    }
);

var app = hostBuilder.Build();
app.Run();