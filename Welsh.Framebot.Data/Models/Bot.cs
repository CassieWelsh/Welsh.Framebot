namespace Welsh.Framebot.Data.Models;

public class Bot
{
    public int BotId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }

    public User User { get; set; }
    public List<BotState> States { get; set; } = [];
    public List<BotChannel> Channels { get; set; } = [];
}