using FictQueueBot.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot.Polling;

var hostBuilder = Host.CreateDefaultBuilder(args);
hostBuilder.ConfigureServices(
    services =>
    {
        services.AddHostedService<BotService>();
        services.AddSingleton<HttpClient>();
        services.AddSingleton<IUpdateHandler,UpdateHandler>();
    }
);

var app = hostBuilder.Build();
app.Run();