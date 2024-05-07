using Welsh.Framebot.Domain.Model;

namespace Welsh.Framebot.Domain.Abstraction;

public abstract class BotState(string name, List<BotAction> actions)
{
    private readonly string _name = name;
    private readonly List<BotAction> _actions = actions;

    public abstract BotState NextState();

    public async Task ExecuteActionsAsync(BotMessage message)
    {
        foreach (var action in _actions)
            await action.ExecuteAsync(message);
    }
}
