using Welsh.Framebot.Domain.Model;

namespace Welsh.Framebot.Domain.Abstraction;

public class BotState(BotActionBase startAction)
{
    private readonly BotActionBase _startAction = startAction ?? throw new ArgumentNullException(nameof(startAction));

    public Task<(BotState? state, string? message)> HandleAsync(BotMessage message, CancellationToken ct)
        => _startAction.ExecuteAsync(message, ct);
}
