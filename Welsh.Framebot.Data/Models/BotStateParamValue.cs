namespace Welsh.Framebot.Data.Models;

public class BotStateParamValue
{
    public int StateId { get; set; }
    public int ParamId { get; set; }
    public string Value { get; set; }

    public BotState State { get; set; }
    public BotStateParam StateParam { get; set; }
}