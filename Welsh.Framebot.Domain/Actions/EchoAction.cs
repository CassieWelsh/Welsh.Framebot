using Welsh.Framebot.Domain.Abstraction;
using Welsh.Framebot.Domain.Model;

namespace Welsh.Framebot.Domain.Actions;

public class EchoAction(string name, BotAction? nextAction, BotState? nextState)
    : BotAction(name, nextAction, nextState)
{
    public override async Task<(BotState? state, string? message)> ExecuteAsync(BotMessage message, CancellationToken ct)
    {
        return (null, message.Text);
    }
}
