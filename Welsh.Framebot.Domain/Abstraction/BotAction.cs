using Welsh.Framebot.Domain.Model;

namespace Welsh.Framebot.Domain.Abstraction;

public abstract class BotAction(string name, byte order)
{
    private readonly string _name = name;

    public byte Order { get; } = order;

    public abstract Task ExecuteAsync(BotMessage message);
}