using Welsh.Framebot.Data.Enums;

namespace Welsh.Framebot.Data.Models;

public class BotStateParam
{
    public int ParamId { get; set; }
    public short StateTypeId { get; set; }
    public string Name { get; set; }
    public ParamTypes ParamType { get; set; }

    public BotStateType StateType { get; set; }
}