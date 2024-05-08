using Welsh.Framebot.Domain.Model;

namespace Welsh.Framebot.Domain.Abstraction;

public abstract class BotState(string name)
{
    private readonly string _name = name;

    public abstract Task<BotState> HandleAsync(BotMessage message, CancellationToken ct);
}
