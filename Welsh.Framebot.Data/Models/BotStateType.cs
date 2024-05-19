namespace Welsh.Framebot.Data.Models;

public class BotStateType
{
    public short StateTypeId { get; set; }
    public string Name { get; set; }

    public List<BotState> States { get; set; }
    public List<BotStateParam> StateParams { get; set; }
}
