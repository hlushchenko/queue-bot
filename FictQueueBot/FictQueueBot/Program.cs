using FictQueueBot.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot.Polling;
using UpdateHandlersManager;

var hostBuilder = Host.CreateDefaultBuilder(args);
hostBuilder.ConfigureServices(
    services =>
    {
        services.AddHostedService<BotService>();
        services.AddSingleton<HttpClient>();
        services.AddSingleton<IUpdateHandler,UpdateHandler>();
        services.AddSingleton<HandlerManager>();
        services.AddSingleton<IHandlerController, Controller>();
    }
);

var app = hostBuilder.Build();
app.Run();