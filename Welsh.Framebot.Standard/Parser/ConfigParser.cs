using System.Text.Json;
using Welsh.Framebot.Domain.Abstraction;

namespace Welsh.Framebot.Standard.Parser;

public class ConfigParser
{
    public BotState? Parse(string config)
    {
        var botConfig = JsonSerializer.Deserialize<BotConfiguration>(config);
        if (botConfig?.States == null || botConfig.States.Count == 0)
            return null;

        BotState? initState = null;
        foreach (var state in botConfig.States.OrderBy(s => s.Id))
        {
            var actions = state.Actions;

            ////var botState = new BotState();
            //initState ??= botState;
        }

        return initState;
    }
}
