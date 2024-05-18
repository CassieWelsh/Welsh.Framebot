namespace Welsh.Framebot.Data.Models;

public class BotActionType
{
    public short ActionTypeId { get; set; }
    public string Name { get; set; }

    public List<BotStateAction> Actions { get; set; } = [];
    public List<BotStateActionParam> Params { get; set; } = [];
}