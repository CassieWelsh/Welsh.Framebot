using Welsh.Framebot.Domain.Model;

namespace Welsh.Framebot.Domain.Abstraction;

public interface IBotMessageProcessor
{
    Task ProcessMessageAsync(BotMessage message, CancellationToken ct);
}