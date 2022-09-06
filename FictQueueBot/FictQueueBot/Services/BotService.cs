using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace FictQueueBot.Services;

public class BotService : BackgroundService
{
    public TelegramBotClient Bot { get; }
    private ILogger<BotService> _logger;
    private IUpdateHandler _handler;

    public BotService(ILogger<BotService> logger, IConfiguration config, HttpClient client, IUpdateHandler handler)
    {
        _logger = logger;
        Bot = new TelegramBotClient(config["Bot:Token"], client);
        _handler = handler;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Bot.StartReceiving(
            updateHandler: _handler.HandleUpdateAsync,
            pollingErrorHandler: _handler.HandlePollingErrorAsync,
            cancellationToken: stoppingToken
        );
        
        var botAccount = await Bot.GetMeAsync(stoppingToken);
        _logger.LogInformation("Now listening on: {Firstname} (https://t.me/{Username})",
            botAccount.FirstName,
            botAccount.Username);
    }
}