namespace Welsh.Framebot.Data.Models;

public class BotStateActionParam
{
    public int ActionId { get; set; }
    public short ParamTypeId { get; set; }
    public string Value { get; set; }

    public BotStateAction Action { get; set; }
    public BotActionTypeParam Param { get; set; }
}