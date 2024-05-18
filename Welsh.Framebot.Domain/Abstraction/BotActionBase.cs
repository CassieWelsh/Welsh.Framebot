using Welsh.Framebot.Domain.Model;

namespace Welsh.Framebot.Domain.Abstraction;

public abstract class BotActionBase
{
    protected readonly BotState? _nextState;
    protected readonly BotActionBase? _nextAction;

    public BotActionBase(BotActionBase? nextAction, BotState? nextState)
    {
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