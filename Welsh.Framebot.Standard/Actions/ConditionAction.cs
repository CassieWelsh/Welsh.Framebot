using Welsh.Framebot.Domain.Abstraction;
using Welsh.Framebot.Domain.Model;

namespace Welsh.Framebot.Standard.Actions;

public class ConditionAction : BotActionBase
{
    public ConditionAction(BotActionBase? nextAction, BotState? nextState)
        : base(nextAction, nextState)
    {
    }

    public override Task<(BotState? state, string? message)> ExecuteAsync(BotMessage message, CancellationToken ct)
    {
        return base.ExecuteAsync(message, ct);
    }
}
