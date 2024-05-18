using Welsh.Framebot.Data.Enums;

namespace Welsh.Framebot.Data.Models;

public class BotChannel
{
    public int BotId { get; set; }
    public ChannelTypes ChannelType { get; set; }
    public string Token { get; set; }

    public Bot Bot { get; set; }
}