namespace Welsh.Framebot.Data.Models;

public class BotStateAction
{
    public int ActionId { get; set; }
    public int StateId { get; set; }
    public short ActionTypeId { get; set; }

    public BotState State { get; set; }
    public BotActionType ActionType { get; set; }
    public List<BotStateActionParam> Params { get; set; } = [];
}