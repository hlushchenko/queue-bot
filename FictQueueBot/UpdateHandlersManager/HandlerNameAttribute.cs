namespace UpdateHandlersManager;

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class HandlerNameAttribute : Attribute
{
    public string Name { get; }

    public HandlerNameAttribute(string name)
    {
        Name = name;
    }
}