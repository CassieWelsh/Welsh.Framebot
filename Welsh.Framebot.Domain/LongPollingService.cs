using Welsh.Framebot.Domain.Abstraction;

namespace Welsh.Framebot.Domain;

public class LongPollingService(IBotChannel channel, IBotStateContainer stateContainer) : ILongPollingService
{
    private readonly IBotChannel _channel = channel;
    private readonly IBotStateContainer<byte> _stateContainer = stateContainer;

    public async Task PollAsync(CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        while (!ct.IsCancellationRequested)
        {
            var messages = await _channel.FetchAsync(ct);
            foreach (var message in messages)
            {
                var state = _stateContainer.GetState(message.UserId);
            }
        }
    }
}
