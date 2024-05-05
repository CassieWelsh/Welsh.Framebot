using Welsh.Framebot.Domain.Model;

namespace Welsh.Framebot.Domain.Abstraction;

public interface IBotChannel
{
    Task SendAsync(BotMessage message, CancellationToken ct);

    Task<List<BotMessage>> FetchAsync(CancellationToken ct);
}
