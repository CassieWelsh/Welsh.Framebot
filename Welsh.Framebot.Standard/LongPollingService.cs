using Microsoft.Extensions.Logging;
using Welsh.Framebot.Domain.Abstraction;

namespace Welsh.Framebot.Standard;

public class LongPollingService(IBotChannel channel, IBotMessageProcessor processor, ILogger<LongPollingService> logger)
{
    private readonly IBotChannel _channel = channel;
    private readonly IBotMessageProcessor _processor = processor;
    private readonly ILogger<LongPollingService> _logger = logger;

    public async Task PollAsync(CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        while (!ct.IsCancellationRequested)
        {
            _logger.LogInformation("Polling");
            var messages = await _channel.FetchAsync(ct);
            foreach (var message in messages)
            {
                var reply = await _processor.ProcessMessageAsync(message, ct);
                if (reply != null)
                    await _channel.SendAsync(new(message.UserId, reply), ct);
            }
        }
    }
}
