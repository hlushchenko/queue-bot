using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace QueueBot.Services;

public class BotService : BackgroundService
{
    public TelegramBotClient Bot { get; }
    private ILogger<BotService> _logger;

    public BotService(ILogger<BotService> logger, IConfiguration config, HttpClient client)
    {
        _logger = logger;
        Bot = new TelegramBotClient(config["Bot:Token"], client);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var bot = await Bot.GetMeAsync(stoppingToken);
        _logger.LogInformation("Now listening on: {Firstname} (https://t.me/{Username})", 
            bot.FirstName, 
            bot.Username);
    }
}