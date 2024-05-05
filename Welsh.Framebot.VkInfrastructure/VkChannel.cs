using VkNet.Abstractions;
using VkNet.Model;
using Welsh.Framebot.Domain.Abstraction;
using Welsh.Framebot.Domain.Model;

namespace Welsh.Framebot.VkInfrastructure;

public class VkChannel(IVkApi channel, BotsLongPollHistoryParams @params) : IBotChannel
{
    private readonly IVkApi channel = channel;
    private readonly BotsLongPollHistoryParams _params = @params;

    public async Task<List<BotMessage>> FetchAsync(CancellationToken ct)
    {
        var poll = await channel.Groups.GetBotsLongPollHistoryAsync(_params, ct);
        _params.Ts += (ulong)poll.Updates.Count;
        return poll.Updates.Select(u => u.Instance)
                           .OfType<MessageNew>()
                           .Select(u => new BotMessage(u.Message.PeerId.GetValueOrDefault(), u.Message.Text))
                           .ToList();
    }

    public Task SendAsync(BotMessage message, CancellationToken ct)
        => channel.Messages.SendAsync(new() { PeerId = message.UserId, Message = message.Text, RandomId = 0 }, ct);
}
