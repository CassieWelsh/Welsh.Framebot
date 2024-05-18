namespace Welsh.Framebot.Data.Models;

public class BotState
{
    public int StateId { get; set; }
    public int BotId { get; set; }
    public string Name { get; set; }

    public Bot Bot { get; set; }
    public List<BotStateAction> Actions { get; set; } = [];
}