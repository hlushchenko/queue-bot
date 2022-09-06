using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UpdateHandlersManager;

namespace FictQueueBot.Services;

public class UpdateHandler : IUpdateHandler
{
    private ILogger<UpdateHandler> _logger;
    private readonly HandlerManager _handlers; 

    public UpdateHandler(ILogger<UpdateHandler> logger, HandlerManager handlers)
    {
        _logger = logger;
        _handlers = handlers;
    }

    public Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Received update from {Name}", update.Message?.From?.Username);
        return _handlers["help"].Invoke(update);
    }

    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}