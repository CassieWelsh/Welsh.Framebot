using Welsh.Framebot.Domain.Model;

namespace Welsh.Framebot.Domain.Abstraction;

public interface IBotMessageProcessor
{
    /// <summary>
    /// Processes the incoming message
    /// </summary>
    /// <param name="message">Incoming message</param>
    /// <param name="ct">Cancellation token</param>
    /// <returns>Reply message for user from bot</returns>
    Task<string?> ProcessMessageAsync(BotMessage message, CancellationToken ct);
}