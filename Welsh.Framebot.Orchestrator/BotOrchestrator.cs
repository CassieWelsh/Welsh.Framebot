using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Welsh.Framebot.Orchestrator;

public class BotOrchestrator(ILogger<BotOrchestrator> logger)
{
    private ILogger<BotOrchestrator> _logger = logger;
    private Dictionary<int, Process> _processes = [];

    public void Enable(int id, string config)
    {
        if (_processes.TryGetValue(id, out _))
        {
            return;
        }

        var p = new ProcessStartInfo()
        {
            FileName = "C:\\Users\\maksi\\Desktop\\Repos\\Welsh.Framebot\\Welsh.Service.Framebot\\bin\\Debug\\net8.0\\Welsh.Service.Framebot.exe",
            //RedirectStandardOutput = true,
            //RedirectStandardError = true,
            //UseShellExecute = false,
            //CreateNoWindow = true
            UseShellExecute = true,
            CreateNoWindow = false
        };

        var process = new Process() { StartInfo = p };
        process.Start();
        _processes.Add(id, process);
    }

    public void Disable()
    {
    }
}
