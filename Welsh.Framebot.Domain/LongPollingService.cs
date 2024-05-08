using Welsh.Framebot.Domain.Abstraction;

namespace Welsh.Framebot.Domain;

public class LongPollingService(IBotChannel channel, IBotMessageProcessor processor)
{
    private readonly IBotChannel _channel = channel;
    private readonly IBotMessageProcessor _processor = processor;

    public async Task PollAsync(CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        while (!ct.IsCancellationRequested)
        {
            var messages = await _channel.FetchAsync(ct);
            foreach (var message in messages)
            {
                await _processor.ProcessMessageAsync(message, ct);
            }
        }
    }
}
