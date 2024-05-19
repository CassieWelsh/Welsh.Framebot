namespace Welsh.Framebot.Data.Models;

public class BotState
{
    public int StateId { get; set; }
    public int BotId { get; set; }
    public string Name { get; set; }
    public int? NextStateId { get; set; }
    public short StateTypeId { get; set; }
    public string? EnterMessage { get; set; }
    public string? ExitMessage { get; set; }

    public Bot Bot { get; set; }
    public BotStateType StateType { get; set; }
    public List<BotStateParamValue> StateParamValues { get; set; }
}