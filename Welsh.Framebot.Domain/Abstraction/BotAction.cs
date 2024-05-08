using Welsh.Framebot.Domain.Model;

namespace Welsh.Framebot.Domain.Abstraction;

public abstract class BotAction(string name)
{
    private readonly string _name = name;

    public abstract Task<BotState> ExecuteAsync(BotMessage message);
}