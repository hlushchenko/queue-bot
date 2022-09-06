using System.Reflection;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;

namespace UpdateHandlersManager;

public class HandlerManager
{
    private Dictionary<string, Func<Update, Task>> _handlers;
    private ILogger<HandlerManager> _logger;

    public HandlerManager(ILogger<HandlerManager> logger, IEnumerable<IHandlerController> controllers)
    {
        _handlers = new Dictionary<string, Func<Update, Task>>();
        _logger = logger;
        RegisterControllers(controllers);
    }

    public Func<Update, Task> this[string name] => _handlers[name];

    private void RegisterControllers(IEnumerable<IHandlerController> controllers)
    {
        foreach (var controller in controllers)
        {
            var type = controller.GetType();
            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                var name = method.GetCustomAttribute<HandlerNameAttribute>()?.Name;
                if (name != null)
                {
                    _handlers.Add(name, method.CreateDelegate<Func<Update, Task>>(controller));
                }
            }
        }
        _logger.LogInformation("Registered {Amount} update handlers", _handlers.Count);
    }
}