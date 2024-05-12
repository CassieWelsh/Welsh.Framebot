using Welsh.Framebot.Domain.Model;

namespace Welsh.Framebot.Domain.Abstraction;

public abstract class BotState(BotAction startAction)
{
    private readonly BotAction _startAction = startAction ?? throw new ArgumentNullException(nameof(startAction));

    public virtual Task<(BotState? state, string? message)> HandleAsync(BotMessage message, CancellationToken ct)
        => _startAction.ExecuteAsync(message, ct);
}
