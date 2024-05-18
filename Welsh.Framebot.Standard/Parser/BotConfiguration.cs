namespace Welsh.Framebot.Standard.Parser;

public class BotConfiguration
{
    public List<State> States { get; set; }
}

public class State
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int BeginningAction { get; set; }
    public List<Action>? Actions { get; set; }
}

public class Action
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Next { get; set; }
    public List<NextAction>? NextActions { get; set; }
    public int? NextState { get; set; }
}

public class NextAction
{
    public string Condition { get; set; }
    public int? Next { get; set; }
}

