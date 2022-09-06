using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using UpdateHandlersManager;

namespace FictQueueBot.Services;

public class Controller : IHandlerController
{
    private ILogger<Controller> _logger;
    public Controller(ILogger<Controller> logger)
    {
        _logger = logger;
    }

    [HandlerName("help")]
    public Task Help(Update update)
    {
        _logger.LogInformation("Update!");
        return Task.CompletedTask;
    }
}