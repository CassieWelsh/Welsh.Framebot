using Welsh.Framebot.Domain.Model;

namespace Welsh.Framebot.Domain.Abstraction;

public abstract class BotAction
{
    private readonly string _name;
    private readonly BotAction? _nextAction;
    private readonly BotState? _nextState;

    public BotAction(string name, BotAction? nextAction, BotState? nextState)
    {
        _name = name;
        _nextAction = nextAction;
        _nextState = nextState;
    }

    public virtual Task<(BotState? state, string? message)> ExecuteAsync(BotMessage message, CancellationToken ct)
    {
        if (_nextAction != null)
            return _nextAction.ExecuteAsync(message, ct);

        return Task.FromResult<ValueTuple<BotState?, string?>>((_nextState, null));
    }
}